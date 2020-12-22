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
        /// V�rification que la liste de questionnaire est bien cr��e et non nule
        /// </summary>
        [TestMethod]
        public void IsDataLoadOk()
        {
          QuestionnaireService context = new QuestionnaireService();

          Assert.IsNotNull(context.GetQuestionnaire(), "Le questionnaire charg� n'est pas conforme ou n'existe pas.");
        }
    }
}
