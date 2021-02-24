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
{   [TestFixture]
  public  class OptionChoicesDALTest
    {
        private surveysdbEntities1 surveydb;
        private SurveyDAL surveyDal;
        private UserDAL userDAL;
        private QuestionDAL questionDAL;
        private OptionChoicesDAL optionChoicesDAL;
        private option_choices optionChoice;
        private surveys survey;
        private users user;
        private questions question;
        private string surveyName = "TestSurvey";
        private string userName = "Teodor";
        private string password = "12345";
        private string SurveyCode;
        private string questionName = "TestQuestion";
        private string newQuestionName = "NewQuestionName";
        private string OptionChoiceName = "TestOptionChoice";
        private string NewOptionChoiceName = "newOptionChoiceName";

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
            question.Input_type_id = 2;
            this.questionDAL.AddQuestion(question);
            this.optionChoicesDAL = new OptionChoicesDAL();
            this.optionChoice = new option_choices();
            this.optionChoice.Question_id = question.Id;
            this.optionChoice.Option_choices_name = OptionChoiceName;
        }
        [TearDown]
        public void TestCleanUp()
        {
            HelperDAL.DeleteQuestion(question);
            HelperDAL.DeleteSurvey(survey);
            HelperDAL.DeleteUser(userName);
        }
        [Test]
        public void AddOptionChoiceToDataBaseShouldBeSuccessful()
        {
            int count = surveydb.option_choices.Count();
            this.optionChoicesDAL.AddOptionChoice(this.optionChoice);
            int secondCount = surveydb.option_choices.Count();
            this.optionChoicesDAL.DeleteOptionChoice(optionChoice);
            Assert.IsTrue(secondCount > count, "Cannot add optionChoice to DataBase.");
        }
        [Test]
        public void DeleteOptioChoiceFromDataBaseShouldBeSuccessful()
        {
            int count = surveydb.option_choices.Count();
            this.optionChoicesDAL.AddOptionChoice(this.optionChoice);
            this.optionChoicesDAL.DeleteOptionChoice(optionChoice);
            int secondCount = surveydb.option_choices.Count();
            Assert.IsTrue(secondCount == count, "Cannot delete optionChoice from DataBase.");
        }
        [Test]
        public void GetOptionChoicesFromDataBaseShouldBeSuccessful()
        {
            HelperDAL.AddOptionChoicesToDataBase(optionChoice);
            List<option_choices> optionChoices = this.optionChoicesDAL.GetOptionsChoices(question);
            HelperDAL.DeleteOptionChoicesFromDataBase(question);
            Assert.AreNotEqual(optionChoices, null, "Cannot get option choices from Database.");
        }
        [Test]
        public void UpdatingOptionChoicesNameShouldBeSuccessful()
        {
            optionChoicesDAL.AddOptionChoice(optionChoice);
            optionChoicesDAL.UpdateOptionsChoice(optionChoice, NewOptionChoiceName);
            option_choices optionChoices = this.surveydb.option_choices.Where(x => x.Id == optionChoice.Id).FirstOrDefault();
            optionChoicesDAL.DeleteOptionChoice(optionChoice);
            Assert.That(optionChoices.Option_choices_name, Is.EqualTo(NewOptionChoiceName));
        }
    }
}

