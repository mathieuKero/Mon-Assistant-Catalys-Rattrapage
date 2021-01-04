using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Web.Models
{
    public class Message
    {
        public DateTime DateStamp { get; set; }
        public string MessageContent { get; set; }
        public MessageType Type { get; set; }
        public enum MessageType
        {
            UserMessage, BotMessage
        }

        public Question LinkedQuestion { get; set; }

#nullable enable
        public string? SelectedAnswer { get; set; }

        public Message()
        {
            DateStamp = DateTime.Now;
        }
    }
}
