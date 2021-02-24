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
{
    [TestFixture]
    public class QuestionDALTest
    {
        private surveysdbEntities1 surveydb;
        private SurveyDAL surveyDal;
        private UserDAL userDAL;
        private QuestionDAL questionDAL;
        private surveys survey;
        private users user;
        private questions question;
        private string surveyName = "TestSurvey";
        private string userName = "Teodor";
        private string password = "12345";
        private string SurveyCode;
        private string questionName = "TestQuestion";
        private string newQuestionName = "NewQuestionName";

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
        }
        [TearDown]
        public void TestCleanUp()
        {

            HelperDAL.DeleteSurvey(survey);
            HelperDAL.DeleteUser(userName);
        }
        [Test]
        public void AddingQuestionToDataBaseShouldBeSuccessful()
        {
            int count = surveydb.questions.Count(x => x.Surveys_id == survey.Id);
            this.questionDAL.AddQuestion(question);
            int secondCount = surveydb.questions.Count(x => x.Surveys_id == survey.Id);
            this.questionDAL.DeleteQuestion(question);
            Assert.IsTrue(secondCount > count, "Cannot add question to DataBase.");

        }
        [Test]
        public void DeletingQuestionFromDataBaseShouldBeSuccessful()
        {
            int count = surveydb.questions.Count(x => x.Surveys_id == survey.Id);
            this.questionDAL.AddQuestion(question);
            this.questionDAL.DeleteQuestion(question);
            int secondCount = surveydb.questions.Count(x => x.Surveys_id == survey.Id);

            Assert.IsTrue(secondCount == count, "Cannot delete question to DataBase.");

        }
        [Test]
        public void DataBaseShouldReturnQuestion()
        {
            this.questionDAL.AddQuestion(question);
            questions question2 = this.questionDAL.GetQuestion(question.Id);
            this.questionDAL.DeleteQuestion(question);
            Assert.That(question, Is.EqualTo(question2));
        }
        [Test]
        public void DataBaseShouldReturnQuestionId()
        {
            this.questionDAL.AddQuestion(question);
            int id = this.questionDAL.GetQuestionId(this.survey.Id, question.Question_name);
            this.questionDAL.DeleteQuestion(question);
            Assert.That(question.Id, Is.EqualTo(id));

        }
        [Test]
        public void DataBaseShouldReturnQuestionsBySurveyId()
        {
            HelperDAL.AddQuestionsToDataBase(question);
            List<questions> questions = this.questionDAL.GetQuestionsBySurveyId(this.survey.Id);
            HelperDAL.DeleteQuestionsBySurveyId(this.survey.Id);
            Assert.AreNotEqual(questions, null);
        }
        [Test]
        public void QestionNameShouldBeUpdated()
        {
            this.questionDAL.AddQuestion(question);
            this.questionDAL.UpdateQuestion(this.question,newQuestionName);
            questions question2 = this.questionDAL.GetQuestion(this.question.Id);
            this.questionDAL.DeleteQuestion(question);
            Assert.AreEqual(question2.Question_name, newQuestionName);
           

        }
    }
}
