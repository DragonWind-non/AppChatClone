using System;
using System.Collections.Generic;

namespace frmClient
{
    public class ChatMessage
    {
        public string Type { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
        public DateTime Time { get; set; }
        public List<string> Users { get; set; }
    }
}
