using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodChildren.Models
{
    public class Chat
    {
            public int Id { get; set; }
            public int ChatId { get; set; }
            public int SenderId { get; set; }
            public int ReciverId { get; set; }
            public string ChatLine { get; set; }
            public DateTime LineTime { get; set; }
            public bool lookIt { get; set; }
    }
    public class ChatView
    {
        public int chatId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public int ReciverId { get; set; }
        public string ReciverName { get; set; }

    }
}
