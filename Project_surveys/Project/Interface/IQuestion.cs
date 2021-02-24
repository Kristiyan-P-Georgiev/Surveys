using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Interface
{
    interface IQuestion
    {
        List<questions> GetQuestionsBySurveyId(int surveyId);

        questions GetQuestion(int questionId);

        int GetQuestionId(int surveyId, string name);

        void DeleteQuestion(questions question);

        void AddQuestion(questions question);

        void UpdateQuestion(questions question, string newQuestionName);
    }
}
