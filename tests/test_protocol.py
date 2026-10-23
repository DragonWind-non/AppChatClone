"""Integration checks against the real TCP server; Python standard library only."""
import json
from pathlib import Path
import socket
import subprocess
import tempfile
import time
import unittest


ROOT = Path(__file__).resolve().parents[1]
SERVER = ROOT / "Server/bin/Release/net10.0/Server.dll"


class Client:
    def __init__(self, port):
        self.socket = socket.create_connection(("127.0.0.1", port), timeout=2)
        self.reader = self.socket.makefile("r", encoding="utf-8-sig")

    def send(self, **message):
        self.socket.sendall((json.dumps(message) + "\n").encode("utf-8"))

    def until(self, message_type):
        for _ in range(20):
            line = self.reader.readline()
            if not line:
                raise AssertionError("Server disconnected unexpectedly")
            message = json.loads(line)
            if message["Type"] == message_type:
                return message
        raise AssertionError(f"No {message_type} message received")

    def close(self):
        self.reader.close()
        self.socket.close()


class ProtocolTests(unittest.TestCase):
    def setUp(self):
        with socket.socket() as probe:
            probe.bind(("127.0.0.1", 0))
            self.port = probe.getsockname()[1]
        self.log = tempfile.TemporaryFile()
        self.process = subprocess.Popen(
            ["dotnet", str(SERVER)], cwd=ROOT, stdin=subprocess.PIPE,
            stdout=self.log, stderr=self.log, text=True,
        )
        self.process.stdin.write(f"{self.port}\n")
        self.process.stdin.flush()
        self.clients = []
        for _ in range(100):
            try:
                client = Client(self.port)
                self.clients.append(client)
                break
            except OSError:
                if self.process.poll() is not None:
                    self.fail("Server failed to start")
                time.sleep(0.05)
        else:
            self.fail("Server startup timed out")

    def tearDown(self):
        for client in self.clients:
            client.close()
        self.process.terminate()
        self.process.wait(timeout=5)
        self.process.stdin.close()
        self.log.close()

    def join(self, username):
        client = Client(self.port)
        self.clients.append(client)
        client.send(Type="JOIN", From=username)
        client.until("USER_LIST")
        return client

    def test_public_sender_is_bound_to_connection(self):
        alice = self.join("Alice")
        alice.send(Type="PUBLIC", From="Admin", Content="Xin chào")
        received = alice.until("PUBLIC")
        self.assertEqual(received["From"], "Alice")
        self.assertEqual(received["Content"], "Xin chào")

    def test_private_sender_is_bound_to_connection(self):
        alice = self.join("Alice")
        bob = self.join("Bob")
        alice.send(Type="PRIVATE", From="Admin", To="Bob", Content="Private")
        self.assertEqual(bob.until("PRIVATE")["From"], "Alice")

    def test_duplicate_join_keeps_original_connection(self):
        alice = self.join("Alice")
        duplicate = Client(self.port)
        self.clients.append(duplicate)
        duplicate.send(Type="JOIN", From="Alice")
        self.assertEqual(duplicate.reader.readline(), "")
        alice.send(Type="PUBLIC", From="Alice", Content="Still connected")
        self.assertEqual(alice.until("PUBLIC")["Content"], "Still connected")

    def test_message_before_join_is_rejected(self):
        guest = self.clients[0]
        guest.send(Type="PUBLIC", From="Admin", Content="Not joined")
        self.assertEqual(guest.reader.readline(), "")

    def test_second_join_cannot_change_identity(self):
        alice = self.join("Alice")
        alice.send(Type="JOIN", From="Admin")
        self.assertEqual(alice.reader.readline(), "")
        replacement = self.join("Alice")
        replacement.send(Type="PUBLIC", From="Alice", Content="Rejoined")
        self.assertEqual(replacement.until("PUBLIC")["Content"], "Rejoined")


if __name__ == "__main__":
    if not SERVER.is_file():
        raise SystemExit("Build first: dotnet build Server/Server.csproj -c Release")
    unittest.main(verbosity=2)
