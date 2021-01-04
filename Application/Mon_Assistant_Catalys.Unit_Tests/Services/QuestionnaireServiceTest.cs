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

        [TestMethod]
        public void IsDataLoadOk()
        {
            QuestionnaireService context = new QuestionnaireService();

            Assert.IsNotNull(context.GetQuestionnaire(), "Le questionnaire chargé n'est pas conforme ou n'existe pas.");
        }

        [TestMethod]
        public void TransformToTreeTest()
        {
            List<Question> questions = new List<Question>();

            questions = this.service.TransformToTree();

            Assert.IsNotNull(questions);
        }

        [TestMethod]
        public void UpdateJsonFilesTest()
        {
           this.service.UpdateJsonFiles();
        }

        [TestMethod]
        public void CreateFileTest()
        {
            this.service.CreateFile("test method");
        }

        [TestMethod]
        public void ConstructTreeTest()
        {
            Question question = new Question();
            Answer answer = new Answer();
            List<Answer> answers = new List<Answer>();

            answer.Id = 101;
            answer.Text = "LCR";

            answers.Add(answer);

            question.IdPosition = 0;
            question.IdQuestion = 1;
            question.Text = "Quel est le type de presatation ?";
            question.IdParentAnswer = 0;
            question.Answers = answers;

            this.service.ConstructTree(question);
        }

        [TestMethod]
        public void GetQuestionnaireTest()
        {
            Assert.IsNotNull(service.GetQuestionnaire());
        }
    }
}