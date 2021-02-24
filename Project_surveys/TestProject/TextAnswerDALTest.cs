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
   public class TextAnswerDALTest
    {
        private surveysdbEntities1 surveydb;
        private SurveyDAL surveyDal;
        private UserDAL userDAL;
        private QuestionDAL questionDAL;
        private TextAnswerDAL textAnswerDAL;
        private text_answers textAnswer;
        private surveys survey;
        private users user;
        private questions question;
        private string surveyName = "TestSurvey";
        private string userName = "Teodor";
        private string password = "12345";
        private string SurveyCode;
        private string questionName = "TestQuestion";
        private string newQuestionName = "NewQuestionName";
        private string TextAnswerText = "ejfeknf111jnejnfejnfefefneknfejnfefe";

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
            this.questionDAL.AddQuestion(question);
            this.textAnswerDAL = new TextAnswerDAL();
            this.textAnswer = new text_answers();
            this.textAnswer.User_name = userName;
            this.textAnswer.Question_id = question.Id;
            this.textAnswer.Answer = TextAnswerText;
        }
        [TearDown]
        public void TestCleanUp()
        {
            HelperDAL.DeleteQuestion(question);
            HelperDAL.DeleteSurvey(survey);
            HelperDAL.DeleteUser(userName);
        }
        [Test]
        public void AddTextAnswerToDataBase()
        {
            int count = surveydb.text_answers.Count();
            this.textAnswerDAL.AddTextAnswer(this.textAnswer);
            int secondcount = surveydb.text_answers.Count();
            this.textAnswerDAL.DeleteTextAnswer(this.textAnswer);
           
            Assert.IsTrue(secondcount > count, "Cannot add textAnswer to DataBase.");

        }
        [Test]
        public void DeleteTextAnswerFromDataBase()
        {
            int count = surveydb.text_answers.Count();
            this.textAnswerDAL.AddTextAnswer(this.textAnswer);

            this.textAnswerDAL.DeleteTextAnswer(this.textAnswer);
            int secondcount = surveydb.text_answers.Count();
            Assert.IsTrue(secondcount == count, "Cannot delete textAnswer from DataBase.");
        }
        [Test]
        public void GetTextAnswersFromDataBase()
        {
            HelperDAL.AddTextAnswersToDataBase(textAnswer);
            List<text_answers> text_Answers = this.textAnswerDAL.GetTextAnswers(question);
            HelperDAL.DeleteTextAnswersFromDataBase(question);
            Assert.AreNotEqual(text_Answers, null, "Cannot get text answers from Database.");
        }

    }
}
 