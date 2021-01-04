using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mon_Assistant_Catalys.Web.Models;
using Mon_Assistant_Catalys.Web.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mon_Assistant_Catalys.Web.Services.Tests
{
    [TestClass()]
    public class QuestionnaireServiceTest
    {
        private QuestionnaireService service = new QuestionnaireService();
        
        private JsonQuestionnaireContext jsonContext= JsonQuestionnaireContext.Instance;

        /// <summary>
        ///     Vérification que la liste de questionnaire est bien créée et non nule
        /// </summary>
        [TestMethod]
        public void IsDataLoadOk()
        {
            QuestionnaireService context = new QuestionnaireService();

            Assert.IsNotNull(context.GetQuestionnaire(), "Le questionnaire chargé n'est pas conforme ou n'existe pas.");
        }

        /// <summary>
        ///     Vérification que l'arbre est bien généré
        /// </summary>
        [TestMethod]
        public void displayTreeTest()
        {
            List<Question> listQuestions = new List<Question>();

            listQuestions = this.service.displayTree();

            Assert.IsNotNull(listQuestions);
        }

        [TestMethod]
        public void UpdateJsonFilesTest()
        {
           service.UpdateJsonFiles();
        }

        [TestMethod]
        public void ConstructTreeTest()
        {
            
        }

        [TestMethod]
        public void GetQuestionnaireTest()
        {
            Assert.IsNotNull(service.GetQuestionnaire());
        }
    }
}