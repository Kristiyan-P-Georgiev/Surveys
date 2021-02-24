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
    public class QuestionDAL : IQuestion
    {
        public surveysdbEntities1 surveyDBcontext = Database.GetConnection();

        public void AddQuestion(questions question)
        {
            surveyDBcontext.questions.Add(question);
            surveyDBcontext.SaveChanges();
        }

        public void DeleteQuestion(questions question)
        {
            surveyDBcontext.questions.Attach(question);
            surveyDBcontext.questions.Remove(question);
            surveyDBcontext.SaveChanges();
        }

        public questions GetQuestion(int questionId)
        {
            return surveyDBcontext.questions.Where(x => x.Id == questionId).FirstOrDefault();
        }

        public int GetQuestionId(int surveyId, string name)
        {

            List<questions> questions = surveyDBcontext.questions.Where(x => x.Surveys_id == surveyId).ToList();
            return questions.Where(x => x.Question_name == name).FirstOrDefault().Id;
        }

        public List<questions> GetQuestionsBySurveyId(int surveyId)
        {
            return surveyDBcontext.questions.Where(x => x.Surveys_id == surveyId).ToList();
        }

        public void UpdateQuestion(questions question, string newQuestionName)
        {
            question.Question_name = newQuestionName;
            surveyDBcontext.SaveChanges();
        }
    }
}
