using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Interface
{
    interface ISurvey
    {
        surveys GetSurveyBySurveyCode(string surveyCode);

        List<surveys> GetAllSurveys();

        List<surveys> GetAllSurveysByUserName(string name);

        int GetSurveyIdBySurveyCode(string surveyCode);

        void AddSurvey(surveys survey);

        void DeleteSurvey(surveys survey);

        void UpdateSurvey(surveys survey, string newSurveyName);
    }
}
