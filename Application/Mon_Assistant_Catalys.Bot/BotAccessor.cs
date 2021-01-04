using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Mon_Assistant_Catalys.Bot.Bots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Bot
{
    public class BotAccessor
    {
        public BotAccessor(ConversationState conversationState)
        {
            conversationState = conversationState ?? throw new ArgumentNullException(nameof(conversationState));
        }

        public static string CatalysBotStateAccessorName { get; } = $"{nameof(BotAccessor)}.CatalysBotState";
        public IStatePropertyAccessor<CatalysBotState> CatalysBotStateStateAccessor { get; internal set; }

        public static string DialogStateAccessorName { get; } = $"{nameof(BotAccessor)}.DialogState";
        public IStatePropertyAccessor<DialogState> DialogStateAccessor { get; internal set; }
        public ConversationState ConversationState { get; }
    }
}
