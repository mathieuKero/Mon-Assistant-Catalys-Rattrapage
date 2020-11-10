using Mon_Assistant_Catalys.Web.Models;

namespace Mon_Assistant_Catalys.Bot.Bots
{
    public class CatalysBotState
    {
        public Question CurrentQuestion { get; set; }
        public Questionnaire Questionnaire { get; set; }
    }
}
