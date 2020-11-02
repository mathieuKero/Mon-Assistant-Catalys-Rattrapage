using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace POC_lecture_json
{
    class Reponse
    {
        #region Properties

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Texte")]
        public string Texte { get; set; }

        public QuestionReponse Question { get; set; }
        #endregion

        #region Constructors

        public Reponse()
        {

        }

        public Reponse(int id, string texte)
        {
            Id = id;
            Texte = texte;
        }


        #endregion
    }
}
