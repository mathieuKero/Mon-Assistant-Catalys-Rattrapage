using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC_lecture_json
{
    public class Questionnaire
    {

        #region Properties

        [JsonProperty("Nom")]
        public string Nom { get; set; }

        [JsonProperty("IdQuestionnaire")]
        public int IdQuestionnaire { get; set; }

        [JsonProperty("Questions")]
        public List<QuestionReponse> Questions { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="Questionnaire"/>.
        /// </summary>
        public Questionnaire()
        {

        }

        #endregion

        #region Methods


        #endregion

    }
}
