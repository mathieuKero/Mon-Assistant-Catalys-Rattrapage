using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC_lecture_json
{
    public class QuestionReponse
    {
        #region Properties

        [JsonProperty("IdQuestionReponse")]
        public int IdQuestionReponse { get; set; }

        [JsonProperty("LabelQuestion")]
        public string LabelQuestion { get; set; }

        [JsonProperty("LabelReponse")]
        public string LabelReponse { get; set; }

        [JsonProperty("IdPosition")]
        public int IdPosition { get; set; }

        [JsonProperty("IdQRParent")]
        public int? IdQRParent { get; set; }

        public QuestionReponse PreviousQuestion { get; set; }

        [JsonProperty("Reponses")]
        public List<QuestionReponse> ListQuestionReponses { get; set; }

        #endregion

        #region Constructors
        public QuestionReponse()
        {

        }

        public QuestionReponse(int idQuestionReponse, string labelQuestion, string labelReponse, int? idQRParent, int idPosition)
        {
            IdQuestionReponse = idQuestionReponse;
            LabelQuestion     = labelQuestion;
            LabelReponse      = labelReponse;
            IdQRParent        = idQRParent;
            IdPosition        = idPosition;            
        }

        #endregion

        #region Methods
            




        #endregion

    }
}
