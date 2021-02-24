using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Interface;
using Project.Data;

namespace Project.Business.DAL
{
    public class TextAnswerDAL : ITextAnswers
    {
        public surveysdbEntities1 surveyDBcontext = Database.GetConnection();

        public void AddTextAnswer(text_answers answer)
        {
            surveyDBcontext.text_answers.Add(answer);
            surveyDBcontext.SaveChanges();
        }

        public void DeleteTextAnswer(text_answers answer)
        {
            surveyDBcontext.text_answers.Attach(answer);
            surveyDBcontext.text_answers.Remove(answer);
            surveyDBcontext.SaveChanges();
        }

        public List<text_answers> GetTextAnswers(questions question)
        {
            return surveyDBcontext.text_answers.Where(c => c.Question_id == question.Id).ToList();
        }
    }
}
