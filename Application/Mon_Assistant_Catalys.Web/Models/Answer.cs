using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Web.Models
{
    public class Answer
    {
        #region Properties

        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        public Question Question { get; set; }
        #endregion

        #region Constructors

        /// <summary>
        ///   Initialise une nouvelle instance de la classe <see cref="Answer"/>.
        /// </summary>
        public Answer()
        {

        }

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="Answer"/>.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="texte"></param>
        public Answer(int id, string texte)
        {
            Id = id;
            Text = texte;
        }


        #endregion
    }
}
