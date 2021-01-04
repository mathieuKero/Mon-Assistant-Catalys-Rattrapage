using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Web.Models
{
    public class Message
    {
        #region Properties

        public DateTime DateStamp { get; set; }
        public string MessageContent { get; set; }
        public MessageType Type { get; set; }
        public enum MessageType
        {
            UserMessage, BotMessage
        }

        public Question LinkedQuestion { get; set; }
                
        public string SelectedAnswer { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="Message"/>.
        /// </summary>
        public Message()
        {
            DateStamp = DateTime.Now;
        }

        #endregion
    }
}
