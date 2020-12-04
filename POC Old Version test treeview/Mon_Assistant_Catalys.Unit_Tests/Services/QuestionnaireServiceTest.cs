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

        [TestMethod()]
        public void QuestionnaireServiceTests()
        {
           
        }

        [TestMethod()]
        public void displayTreeTest()
        {
            List<Question> listQuestions = new List<Question>();

            listQuestions.Add(new Question(1, "test question", null , 1, null));
            Assert.IsNotNull(this.service.displayTree(listQuestions));
        }

        [TestMethod()]
        public void UpdateJsonFilesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ConstructTreeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetQuestionnaireTest()
        {
            Assert.Fail();
        }
    }
}