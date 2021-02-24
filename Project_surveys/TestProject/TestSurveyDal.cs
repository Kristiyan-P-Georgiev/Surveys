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
   public class TestSurveyDal
    {
        private surveysdbEntities1 surveydb;
        private SurveyDAL surveyDal;
        private UserDAL userDAL;
        private surveys survey;
        private users user;
        private string surveyName = "TestSurvey";
        private string userName = "Teodor";
        private string password = "12345";
        private string SurveyCode;

        [SetUp]
        public void TestInit()
        {
            surveydb = Database.GetConnection();
            surveyDal = new SurveyDAL();
            userDAL = new UserDAL();
            user = new users();
            user.User_name = userName;
            user.User_password = password;
            survey = new surveys();
            survey.Name = surveyName;
            survey.users = user;
            SurveyCode = HelperDAL.GenerateRandomSurveyCode();
            survey.Survey_code = SurveyCode;
        }
        [Test]
        public void SurveyShouldBeAddedSuccessfully()
        {
            int firstSurveyCount = surveydb.surveys.Count();
            this.surveyDal.AddSurvey(survey);
            int secondSurveyCount = surveydb.surveys.Count();
            // surveydb.surveys.Where(x => x.Name == surveyName).de;
            this.surveyDal.DeleteSurvey(survey);
            this.userDAL.DeleteUserByName(userName);
            Assert.IsTrue(secondSurveyCount > firstSurveyCount,"Survey cannot be added to DataBase");
        }
        [Test]
        public void DeletedSuccessfullySurvey()
        {
            this.surveyDal.AddSurvey(survey);
            this.surveyDal.DeleteSurvey(survey);
            surveys testSurvey = this.surveyDal.GetSurveyBySurveyCode(SurveyCode);
            this.userDAL.DeleteUserByName(userName);
            Assert.AreEqual(testSurvey, null, "Survey isn't deleted.");
        }
        [Test]
        public void DataBaseShouldReturnAllSurveys()
        {
            int surveysCount = this.surveydb.surveys.Count();
            List<surveys> surveys = this.surveyDal.GetAllSurveys();
            int secondCount = surveys.Count();
            Assert.IsNotNull(surveys);
            Assert.That(surveysCount, Is.EqualTo(secondCount));
        }
        [Test]
        public void DatabaseShouldReturnSurveysByUserName()
        {
            HelperDAL.AddTestSurveysToDataBase(survey);
            int surveysCount = this.surveydb.surveys.Count(x => x.User_name == userName);
            List<surveys> surveys = this.surveyDal.GetAllSurveysByUserName(userName);
            int secondCount = surveys.Count();
            HelperDAL.DeleteSurveysFromDataBase(userName);
            this.userDAL.DeleteUserByName(userName);
            Assert.IsNotNull(surveys);
            Assert.That(surveysCount, Is.EqualTo(secondCount));
        }
        [Test]
        public void ShouldReturnSirveyByCode()
        {
            this.surveyDal.AddSurvey(survey);
            surveys surveyFromDataBase = this.surveyDal.GetSurveyBySurveyCode(SurveyCode);
            this.surveyDal.DeleteSurvey(survey);
            HelperDAL.DeleteUser(userName);
            Assert.IsNotNull(surveyFromDataBase);
            Assert.That(survey, Is.EqualTo(surveyFromDataBase));
        }
        [Test]
        public void SurveyNameShouldBeDifferent()
        {
            this.surveyDal.AddSurvey(survey);
            string newSurveyName = "NewName";
            this.surveyDal.UpdateSurvey(survey, newSurveyName);
            surveys survey2 =  this.surveyDal.GetSurveyBySurveyCode(SurveyCode);
            this.surveyDal.DeleteSurvey(survey);
            HelperDAL.DeleteUser(userName);
            Assert.AreSame(newSurveyName, survey2.Name);
        }
    }
}
