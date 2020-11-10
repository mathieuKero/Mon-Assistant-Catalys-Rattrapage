using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Mon_Assistant_Catalys.Web.Models
{
    /// <summary>
    ///     Cette classe va lire les données du questionnaire.
    /// </summary>
    public sealed class JsonQuestionnaireContext    
    {
        #region Fields

        /// <summary>
        ///     Questionnaire.
        /// </summary>
        public Questionnaire Questionnaire { get; private set; }

        private static JsonQuestionnaireContext instance = null;

        #endregion


        #region Constructors

        public JsonQuestionnaireContext()
        {
            
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Récupération des données du fichier Json et insertion dans Questionnaire
        /// </summary>
        public Questionnaire LoadData()
        {
            string path = "Files\\data_1_CURRENT.json";
            Questionnaire questionnaire = new Questionnaire();


            // deserialize JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            {

                JsonSerializer serializer = new JsonSerializer();
                questionnaire = (Questionnaire)serializer.Deserialize(file, typeof(Questionnaire));
            }
            return questionnaire;

        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="Id"></param>
        public void FindData(int Id)
        {

       }

        /// <summary>
        ///     Edition d'une partie du questionnaire ( Question / Réponse )
        /// </summary>
        /// <param name="Id"></param>
        public void EditData(int id)
        {
            /// Réflexion : Récupérer le json avec loaddata puis modifier ? ou alors modifier les données des classes puis mettre à jour le json à partir des classes ?
            /// A VOIR
            Question question = new Question();
            Reponse reponse = new Reponse();


            if (question == null)
            {
                //reponse = .Questionnaire.Questions.Select(x => x.Reponses.FirstOrDefault(c => c.Id == id)).ToList().FirstOrDefault();
            }
            

        }

        public void AddData()
        {

        }

        #endregion

        
        #region Properties

        /// <summary>
        ///     Instancie ou récupère l'instance de JsonQuestionnaireContexte
        /// </summary>
        public static JsonQuestionnaireContext Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JsonQuestionnaireContext();
                }
                return instance;
            }
        }

        #endregion
    }
}