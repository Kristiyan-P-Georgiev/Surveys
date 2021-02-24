using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Project.Business.DAL;
using Project.Business;
using Project.Data;

namespace TestProject
{  [TestFixture]
   public class InputTypesDALTest
    {
        private surveysdbEntities1 surveydb;
        private SurveyDAL surveyDal;
        private UserDAL userDAL;
        private QuestionDAL questionDAL;
        private InputTypesDAL inputTypesDAL;
        private input_types inputTypes;
        private surveys survey;
        private users user;
        private questions question;
        private string surveyName = "TestSurvey";
        private string userName = "Teodor";
        private string password = "12345";
        private string SurveyCode;
        private string questionName = "TestQuestion";
        private string newQuestionName = "NewQuestionName";
        private string TestInputTypesName = "text";
        [SetUp]
        public void TestInit()
        {
            surveydb = Database.GetConnection();
            surveyDal = new SurveyDAL();
            userDAL = new UserDAL();
            questionDAL = new QuestionDAL();
            user = new users();
            user.User_name = userName;
            user.User_password = password;
            HelperDAL.AddUser(user);
            survey = new surveys();
            survey.Name = surveyName;
            //survey.users = user;
            survey.User_name = userName;
            SurveyCode = HelperDAL.GenerateRandomSurveyCode();
            survey.Survey_code = SurveyCode;
            HelperDAL.AddSurvey(survey);
            question = new questions();
            question.Question_name = questionName;
            question.Surveys_id = survey.Id;
            question.Input_type_id = 1;
            HelperDAL.AddQuestion(question);
            this.inputTypesDAL = new InputTypesDAL();
            this.inputTypes = new input_types();
        }
        [TearDown]
        public void TestCleanUp()
        {
            HelperDAL.DeleteQuestion(question);
            HelperDAL.DeleteSurvey(survey);
            HelperDAL.DeleteUser(userName);
        }
        [Test]
        public void DataBaseShouldReturnInputTypeName()
        {
            string inputTypeName = inputTypesDAL.GetInputTypeName(question);
            Assert.That(inputTypeName, Is.EqualTo(TestInputTypesName));
        }
    }
}
