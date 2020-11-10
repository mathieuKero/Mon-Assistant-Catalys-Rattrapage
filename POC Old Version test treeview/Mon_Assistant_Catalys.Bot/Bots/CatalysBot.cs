using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Mon_Assistant_Catalys.Bot.Dialogs;
using Mon_Assistant_Catalys.Web.Models;
using Mon_Assistant_Catalys.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Bot.Bots
{
    public class CatalysBot : IBot
    {

        private readonly DialogSet dialogs;

        public CatalysBot(BotAccessor botAccessor)
        {
            IStatePropertyAccessor<DialogState> dialogState = botAccessor.DialogStateAccessor;

            dialogs = new DialogSet(dialogState);
            dialogs.Add(MainDialog.Instance);
            dialogs.Add(new ChoicePrompt("choicePrompt"));
            dialogs.Add(new TextPrompt("textPrompt"));
            dialogs.Add(new NumberPrompt<int>("numberPrompt"));
            BotAccessor = botAccessor;
        }

        public BotAccessor BotAccessor { get; }


        public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                // initialize state if necessary
                var state = await BotAccessor.CatalysBotStateStateAccessor.GetAsync(turnContext, () => new CatalysBotState(), cancellationToken);

                turnContext.TurnState.Add("BotAccessor", BotAccessor);

                var dialogCtx = await dialogs.CreateContextAsync(turnContext, cancellationToken);

                if (dialogCtx.ActiveDialog == null)
                {
                    await dialogCtx.BeginDialogAsync(MainDialog.Id, cancellationToken);
                }
                else
                {
                    await dialogCtx.ContinueDialogAsync(cancellationToken);
                }

                await BotAccessor.ConversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            }
        }
    }
}
