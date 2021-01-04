using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Bot.Dialogs
{
    public class MainDialog : WaterfallDialog
    {

        public MainDialog(string dialogId, IEnumerable<WaterfallStep> steps = null) : base(dialogId, steps)
        {
            AddStep(async (stepContext, cancellationToken) =>
            {
                return await stepContext.PromptAsync("choicePrompt",
                    new PromptOptions
                    {
                        Prompt = stepContext.Context.Activity.CreateReply("Ceci est une question test"),
                        Choices = new[] { new Choice { Value = "Choix 1" }, new Choice { Value = "Choix 2" } }.ToList()
                    });
            });

            AddStep(async (stepContext, cancellationToken) =>
            {
                var response = (stepContext.Result as FoundChoice)?.Value;

                if (response == "Choix 1")
                {
                    
                }

                if (response == "Choix 2")
                {
                    
                }

                return await stepContext.NextAsync();
            });

            AddStep(async (stepContext, cancellationToken) => { return await stepContext.ReplaceDialogAsync(Id); });
        }

        public static string Id => "mainDialog";

        public static MainDialog Instance { get; } = new MainDialog(Id);    
    }
}
