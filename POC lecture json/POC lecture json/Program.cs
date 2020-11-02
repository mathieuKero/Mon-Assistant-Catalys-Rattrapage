using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace POC_lecture_json
{
    class Program
    {
        static Questionnaire questionnaire = new Questionnaire();
        static void Main(string[] args)
        {
            int posQuestion = 0;
            bool valResult = false;
            string result = "";
            questionnaire = LoadData();

            // Envoyer la première question
            Console.WriteLine(questionnaire.Questions[0].LabelQuestion);

            // Ajout d'une questionReponse à une questionRéponse parente => Pas sûr du fonctionnement
            QuestionReponse QuestionParent = new QuestionReponse();
            QuestionReponse QuestionToAdd = new QuestionReponse();
            // Ajout de QuestionReponse à une questionReponse parente
            QuestionParent.ListQuestionReponses.Add(QuestionToAdd);

            // Suppression de QuestionReponse d'une questionReponse parente
            QuestionParent.ListQuestionReponses.Remove(QuestionToAdd);

            // Modification de QuestionReponse d'une questionReponse parente
            QuestionParent.ListQuestionReponses[1].IdQRParent = 2;

            // Boucle while => tant qu'on est pas à la dernière question ( position 7)
            while (posQuestion != 7)
             {
                 // Pour poser les autres questions sans en poser 2 au premier passage dans la boucle
                 if (posQuestion != 0)
                 {
                     // Envoyer la question
                     // Récupérer l'index du tableau de la question à envoyer en fonction de l'idQuestion reçu
                     //Console.WriteLine(questionnaire.Questions[0].Texte);
                 }

                 // Récupère le texte de la réponse
                 result = Console.ReadLine();

                 // Rechercher la réponse associée
                 foreach (var ques in questionnaire.Questions)
                 {
                     if (valResult == false)
                     {
                         if(ques.LabelReponse == result)
                         {
                                 result = ques.LabelReponse;
                                 posQuestion = ques.IdPosition; // Mise à jour de la position de la question actuelle
                                 valResult = true;
                         }
                     }

                 }

                // Utiliser l'id de la réponse actuelle pour trouver la question associée
                Console.WriteLine(questionnaire.Questions[posQuestion].LabelQuestion);
                //Console.WriteLine(posQuestion);

             }
        }

        /// <summary>
        /// Récup données
        /// </summary>
        /// <returns></returns>
        private static Questionnaire LoadData()
        {
            Questionnaire questionnaire = new Questionnaire();
            string path = @"D:\Developpement\Master C#\rattrapage\POC lecture json\POC lecture json\data_1_CURRENT.json";

            // desedrialize JSON directly from a file
            using (StreamReader file = File.OpenText(path))
            {

                JsonSerializer serializer = new JsonSerializer();
                questionnaire = (Questionnaire)serializer.Deserialize(file, typeof(Questionnaire));
            }

            return questionnaire;
        }
    }
}
