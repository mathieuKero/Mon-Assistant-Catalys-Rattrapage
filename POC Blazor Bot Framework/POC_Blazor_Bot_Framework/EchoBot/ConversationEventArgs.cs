using Microsoft.Bot.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_Blazor_Bot_Framework.EchoBot
{
    public class ConversationEventArgs : EventArgs
    {
        public Activity Activity { get; set; }
    }
}
