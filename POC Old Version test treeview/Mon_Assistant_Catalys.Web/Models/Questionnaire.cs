using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Web.Models
{
    /// <summary>
    /// COntiens les informations relatives au questionnaire (Liste des questionReponses etc.)
    /// </summary>
    public class Questionnaire
    {

        #region Properties
       
        [JsonProperty("Nom")]
        public string Nom { get; set; }

        [JsonProperty("IdQuestionnaire")]
        public int IdQuestionnaire { get; set; }

        [JsonProperty("Questions")]
        public List<Question> Questions { get; set; }

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
