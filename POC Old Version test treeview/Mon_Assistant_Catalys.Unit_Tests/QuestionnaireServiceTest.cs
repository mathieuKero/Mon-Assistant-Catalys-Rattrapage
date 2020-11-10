using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mon_Assistant_Catalys.Web.Services;
using Mon_Assistant_Catalys.Web.Models;
using System.Collections.Generic;

namespace Mon_Assistant_Catalys.Unit_Tests
{
    [TestClass]
    public class QuestionnaireServiceTest
    {
        /// <summary>
        /// Vérification que la liste de questionnaire est bien créée et non nule
        /// </summary>
        [TestMethod]
          public void IsDataLoadOk()
        {
            //Arrange
            QuestionnaireService context = new QuestionnaireService();

            //Act
            Assert.IsNotNull(context.GetQuestionnaire(), "Le questionnaire chargée n'est pas conforme ou n'existe pas.");
        }
    }
}
