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

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("IdParentAnswer")]
        public int? IdParentAnswer { get; set; }

        [JsonProperty("IdPosition")]
        public int IdPosition { get; set; }

        [JsonProperty("Answers")]
        public List<Answer> Answers { get; set; }

        [JsonIgnore]
        public Question PreviousQuestion { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="Question"/>.
        /// </summary>
        public Question()
        {

        }

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="Question"/>.
        /// </summary>
        /// <param name="idQuestion"></param>
        /// <param name="text"></param>
        /// <param name="idParentAnswer"></param>
        /// <param name="idPosition"></param>
        /// <param name="answers"></param>
        public Question(int idQuestion, string text, int? idParentAnswer, int idPosition, List<Answer> answers)
        {
            IdQuestion = idQuestion;
            Text = text;
            IdParentAnswer = idParentAnswer;
            IdPosition = idPosition;
            Answers = answers;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Méthode permettant de vérifier si il y a une question après la réponse actuelle
        /// </summary>
        /// <returns></returns>
        public bool IsQuestionAfterAnwser()
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
