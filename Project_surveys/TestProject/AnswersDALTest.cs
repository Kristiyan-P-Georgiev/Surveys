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
   public class AnswersDALTest
    {
        private surveysdbEntities1 surveydb;
        private SurveyDAL surveyDal;
        private UserDAL userDAL;
        private QuestionDAL questionDAL;
        private OptionChoicesDAL optionChoicesDAL;
        private AnswersDAL answersDAL;
        private answers answer;
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
            this.optionChoicesDAL.AddOptionChoice(optionChoice);
            this.answersDAL = new AnswersDAL();
            this.answer = new answers();
            this.answer.User_name = userName;
            this.answer.Question_option_id = optionChoice.Id;
        }
        [TearDown]
        public void TestCleanUp()
        {
            HelperDAL.DeleteOptionChoice(optionChoice);
            HelperDAL.DeleteQuestion(question);
            HelperDAL.DeleteSurvey(survey);
            HelperDAL.DeleteUser(userName);
        }
        [Test]
        public void AddAnswerToDataBaseShouldBeSuccessful()
        {
            int count = surveydb.answers.Count();
            this.answersDAL.AddAnswer(this.answer);
            int secondCount = surveydb.answers.Count();
            this.answersDAL.DeleteAnswer(answer);
            Assert.IsTrue(secondCount > count, "Cannot add answer to DataBase.");
        }
        [Test]
        public void DeleteAnswerFromDataBaseShuouldBeSuccessful()
        {
            int count = surveydb.answers.Count();
            this.answersDAL.AddAnswer(answer);
            this.answersDAL.DeleteAnswer(answer);
            int secondCount = surveydb.answers.Count();
            Assert.IsTrue(count == secondCount,"Cannot delete answer from DataBase.");
        }
        [Test]
        public void DataBaseShouldReturnAnswersByOptionChoiceId()
        {
            HelperDAL.AddAnswersToDataBase(answer);
            List<answers> answers = answersDAL.GetAnswers(optionChoice.Id);
            HelperDAL.DeleteAnswersFromDataBase(optionChoice.Id);
            Assert.AreNotSame(answers, null,"Cannot get answers from DataBase.");
        }
    }
}
