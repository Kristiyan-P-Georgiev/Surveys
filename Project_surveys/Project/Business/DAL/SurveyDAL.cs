using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Interface;
using Project.Data;
using System.Data.Entity;

namespace Project.Business.DAL
{
    public class SurveyDAL : ISurvey
    {
        public surveysdbEntities1 surveyDBcontext = Database.GetConnection();

        public void AddSurvey(surveys survey)
        {
            surveyDBcontext.surveys.Add(survey);
            surveyDBcontext.SaveChanges();
        }

        public void DeleteSurvey(surveys survey)
        {
            surveyDBcontext.surveys.Attach(survey);
            surveyDBcontext.surveys.Remove(survey);
            surveyDBcontext.SaveChanges();
        }

        public List<surveys> GetAllSurveys()
        {
            return surveyDBcontext.surveys.ToList();
        }

        public List<surveys> GetAllSurveysByUserName(string name)
        {
            return surveyDBcontext.surveys.Where(x => x.User_name == name).ToList();
        }

        public surveys GetSurveyBySurveyCode(string surveyCode)
        {
            return surveyDBcontext.surveys.Where(c => c.Survey_code == surveyCode).FirstOrDefault();
        }

        public int GetSurveyIdBySurveyCode(string surveyCode)
        {
            return surveyDBcontext.surveys.Where(x => x.Survey_code == surveyCode).FirstOrDefault().Id;
        }

        public void UpdateSurvey(surveys survey, string newSurveyName)
        {
            survey.Name = newSurveyName;
            surveyDBcontext.SaveChanges();
        }
    }
}
