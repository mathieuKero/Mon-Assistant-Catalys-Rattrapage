using Mon_Assistant_Catalys.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Instanciation du service questionnaire
        /// On récupère les données provenant du contexte de données
        /// </summary>
        public QuestionnaireService()
        {
            questionnaire = jsonContext.LoadData();
        }

        /// <summary>
        /// Méthode de transformation de la liste de question en question / réponses imbriqués les unes dans les autres 
        /// Cela restructure la liste en arbre pour en permettre la manipulation
        /// </summary>
        /// <param name="q">Questionnaire à restructurer</param>
        /// <returns>Questionnaire restructuré</returns>
        public List<Question> displayTree(List<Question> q)
        {
            //Optention des premières questions
            q = questionnaire.Questions.FindAll(q => q.IdReponseParent == 0);

            //Pour chacun des questionnaires, on relance le tri
            foreach (Question question in q)
            {
                ConstructTree(question);
            }

            return q;
        }

        /// <summary>
        /// Méthode récurcive => à partir de la question fournie en paramètre, on associe les question enfantes
        /// </summary>
        /// <param name="question">Question à associer</param>
        public void ConstructTree(Question question)
        {
            if (question.Reponses != null)
            {
                //Pour chacunes des réponses de la question : association à la question enfante
                foreach (Reponse reponse in question.Reponses)
                {
                    //Si la question associée à la réponse est nulle c'est qu'elle n'a pas été encore attribuée. 
                    //A l'inverse si la question associée à la réponse n'est pas nulle c'est que la question enfant à été associée et qu'il ne faut pas la retraiter
                    if (reponse.Question == null)
                    {
                        //Attribution de la question parente et enfante
                        reponse.Question = questionnaire.Questions.Find(q => q.IdReponseParent == reponse.Id);
                        reponse.Question.PreviousQuestion = question;

                        //Attribution sur la question enfante
                        ConstructTree(reponse.Question);

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
        /// Retrourne l'instance de questionnaire
        /// </summary>
        /// <returns>Instance de questionnaire</returns>
        public Questionnaire GetQuestionnaire()
        {
            return questionnaire;
        }
    }
}