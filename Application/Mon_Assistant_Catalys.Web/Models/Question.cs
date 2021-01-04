using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Web.Models
{
    /// <summary>
    /// Ensemble des questions réponses des questionnaire. Les données sont incluses dans la classe Questionnaire
    /// </summary>
    public class Question
    {

        #region Properties
       
        [JsonProperty("IdQuestion")]
        public int IdQuestion { get; set; }

        [JsonProperty("Texte")]
        public string Texte { get; set; }

        [JsonProperty("IdReponseParent")]
        public int? IdReponseParent { get; set; }

        [JsonProperty("IdPosition")]
        public int IdPosition { get; set; }

        [JsonProperty("Answers")]
        public List<Answer> Answers { get; set; }

        [JsonIgnore]
        public Question QuestionPrecedente { get; set; }

        #endregion

        #region Constructors
        public Question()
        {

        }

        public Question(int idQuestion, string texte, int? idReponseParent, int idPosition, List<Answer> answers)
        {
            IdQuestion = idQuestion;
            Texte = texte;
            IdReponseParent = idReponseParent;
            IdPosition = idPosition;
            Answers = answers;
        }

        #endregion

        #region Methods
        public bool ReponseApresQuestion()
        {
            try
            {
                List<Answer> reps = this.Answers;
                if (reps == null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }

}
