# LanChat - AppChat (Phiên bản viết trên Project gốc)

## Cấu trúc dự án
Dự án được xây dựng trực tiếp vào 3 folder gốc như đúng yêu cầu của bạn:

1. **Server** (`Server\Server.csproj`):
   - Chạy trên `.NET 10`, ứng dụng Console.
   - Quản lý đa luồng (Task.Run) cho từng kết nối TCP.
   - Relay tin nhắn JSON (Public/Private/Broadcast User List).

2. **RegisterClient** (`RegisterClient\RegisterClient.csproj`):
   - Màn hình nhập IP, Port, Username.
   - Sẽ tự động gọi `MainClient` nếu mọi thứ hợp lệ thông qua tiến trình ngầm (mô phỏng gọi executable chuyên biệt).

3. **MainClient** (`frmClient\MainClient.csproj`):
   - Giao diện thao tác chính.
   - Hiển thị danh sách Online, màu sắc tin nhắn (Đen: Chat public, Xanh: Chat private, Xanh lá/Đỏ: Người dùng ra/vào).
   - Nhấn Đúp Chuột hoặc nhấn Chuột Phải -> ContextMenu chọn mục vào tên User trên danh sách để tự mở form `PrivateChatForm`.

## Hướng dẫn khởi chạy

### Chạy Server
Mở Terminal, trỏ vào thư mục `Server` và gõ:
```powershell
dotnet run --project Server.csproj
```
*(Server sẽ hỏi bạn Port, hoặc bạn có thể ấn Enter để lấy Port 8888 mặc định).*

### Chạy Ứng dụng Client (App chat)
Mở một (hoặc nhiều) Terminal khác, trỏ vào thư mục `RegisterClient` và gõ:
```powershell
dotnet run --project RegisterClient.csproj
```
*(Điền tên đăng nhập tùy ý, IP là 127.0.0.1 và ấn "Kết Nối". Nó sẽ đóng cửa sổ này và tự động gọi Form chính của `MainClient` lên cực kỹ mượt mà!)*

Bạn có thể mở đồng thời 2-3 Terminal gõ `dotnet run --project RegisterClient.csproj` để mô phỏng 2-3 người đang nói chuyện với nhau trong phòng.

Chúc bạn có trải nghiệm tuyệt vời với "đứa con tinh thần" của mình! Dữ liệu chạy hoàn toàn chuẩn JSON và không bị Crash (Thread-Safe an toàn tuyệt đối).
