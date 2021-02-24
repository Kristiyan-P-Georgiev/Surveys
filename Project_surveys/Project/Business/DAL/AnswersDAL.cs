using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Interface;
using Project.Data;

namespace Project.Business.DAL
{
   public class AnswersDAL:IAnswers
    {
        public surveysdbEntities1 surveyDBcontext = Database.GetConnection();

        public void AddAnswer(answers answer)
        {
            surveyDBcontext.answers.Add(answer);
            surveyDBcontext.SaveChanges();
        }

        public void DeleteAnswer(answers answer)
        {
            surveyDBcontext.answers.Attach(answer);
            surveyDBcontext.answers.Remove(answer);
            surveyDBcontext.SaveChanges();
        }

        public List<answers> GetAnswers(int optionId)
        {
            return surveyDBcontext.answers.Where(x => x.Question_option_id == optionId).ToList();
        }
    }
}
