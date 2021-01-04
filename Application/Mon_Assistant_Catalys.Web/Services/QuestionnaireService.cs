using Mon_Assistant_Catalys.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Mon_Assistant_Catalys.Web.Services
{
    /// <summary>
    ///     Liaison vers les données et appel des fonction. 
    ///     C'est une couche intermédiaire entre les models / views vers le dossier data.
    /// </summary>
    public class QuestionnaireService
    {
        private JsonQuestionnaireContext jsonContext = JsonQuestionnaireContext.Instance;

        private readonly Questionnaire questionnaire = new Questionnaire();
        
        /// <summary>
        ///     Instanciation du service questionnaire
        ///     On récupère les données provenant du contexte de données
        /// </summary>
        public QuestionnaireService()
        {
            questionnaire = jsonContext.LoadData();
        }

        /// <summary>
        ///    Méthode de transformation de la liste de questions en questions / réponses imbriquées les unes dans les autres 
        ///    Cela restructure la liste en arbre pour en permettre la manipulation
        /// </summary>
        /// <returns>Questionnaire restructuré</returns>
        public List<Question> displayTree()
        {
            List<Question> questions = new List<Question>();

            //Récupération des premières questions
            questions = questionnaire.Questions.FindAll(q => q.IdParentAnswer == 0);

            //Pour chacun des questionnaires, on relance le tri
            foreach (Question question in questions)
            {
                ConstructTree(question);
            }

            return questions;
        }

        /// <summary>
        ///     Mise à jour des fichiers Json
        /// </summary>
        public void UpdateJsonFiles()
        {
            // On créer un fichier json à partir du questionnaire
            using (StreamWriter file = File.CreateText("Files\\data_1_CURRENT_TMP.json"))
            {
                
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;

                //serialize object directly into file stream
                serializer.Serialize(file, questionnaire);
            }
            
            // On compare les deux fichiers JSON pour voir si des différences existent
            string jsonText1 = File.ReadAllText("Files\\data_1_CURRENT_TMP.json");
            string jsonText2 = File.ReadAllText("Files\\data_1_CURRENT.json");

            JObject json1 = JObject.Parse(jsonText1);
            JObject json2 = JObject.Parse(jsonText2);

            bool areEqual = JToken.DeepEquals(json1, json2);

            // Si aucune différence, le fichier nouvellement créé est supprimé
            if (areEqual == true)
            {
                // Supprimer fichier _TMP
                File.Delete("Files\\data_1_CURRENT_TMP.json");
            }
            else
            {
                // Renommer les deux fichiers avec les suffixes correspondant
                File.Delete("Files\\data_1_OLD.json");
                File.Move("Files\\data_1_CURRENT.json", "Files\\data_1_OLD.json");
                File.Move("Files\\data_1_CURRENT_TMP.json", "Files\\data_1_CURRENT.json");
                
            }
        }



        /// <summary>
        ///     Création du fichier de sortie à la fin du chat avec l'assistant.
        /// </summary>
        /// <param name="fileText"></param>
        public void CreateFile(string fileText)
        {
            string actualDate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

            string path = "Files\\Fichier-sortie-" + actualDate + ".txt";

            using (StreamWriter file = File.CreateText(path))
            {
                file.WriteLine(fileText);
            }

        }

        /// <summary>
        ///     Méthode récurcive => à partir de la question fournie en paramètre, on associe les question enfantes
        /// </summary>
        /// <param name="question">Question à associer</param>
        public void ConstructTree(Question question)
        {
            if (question.Answers != null)
            {
                //Pour chacunes des réponses de la question : association à la question enfante
                foreach (Answer answer in question.Answers)
                {
                    //Si la question associée à la réponse est nulle c'est qu'elle n'a pas été encore attribuée. 
                    //A l'inverse si la question associée à la réponse n'est pas nulle c'est que la question enfant à été associée et qu'il ne faut pas la retraiter
                    if (answer.Question == null)
                    {
                        //Attribution de la question parente et enfante
                        answer.Question = questionnaire.Questions.Find(q => q.IdParentAnswer == answer.Id);
                        answer.Question.PreviousQuestion = question;

                        //Attribution sur la question enfante
                        ConstructTree(answer.Question);

                    }
                }
                //Si toutes les réponses ont été associées à leur question, alors retour sur l'élément parent
                if (question.PreviousQuestion != null)
                {
                    ConstructTree(question.PreviousQuestion);
                }
            }
            else
            {
                //Si la question ne contient pas de réponse c'est que l'on se trouve dans le message de fin
                ConstructTree(question.PreviousQuestion);
            }
        }

        /// <summary>
        ///     Retrourne l'instance de questionnaire
        /// </summary>
        /// <returns>Instance de questionnaire</returns>
        public Questionnaire GetQuestionnaire()
        {
            return questionnaire;
        }
    }
}