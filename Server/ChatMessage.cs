using System;
using System.Collections.Generic;

namespace Server
{
    public class ChatMessage
    {
        public string Type { get; set; }   // "PUBLIC" | "PRIVATE" | "SYSTEM" | "JOIN" | "LEAVE" | "USER_LIST"
        public string From { get; set; }   // Username người gửi
        public string To { get; set; }     // Username người nhận (Dành cho PRIVATE)
        public string Content { get; set; } // Nội dung
        public DateTime Time { get; set; } // Thời gian
        public List<string> Users { get; set; } // Dùng riêng cho Type="USER_LIST" để server gửi ds online
    }
}
