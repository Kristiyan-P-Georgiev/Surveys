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
    public class OptionChoicesDAL : IOptionChoice
    {
        public surveysdbEntities1 surveyDBcontext = Database.GetConnection();

        public void AddOptionChoice(option_choices option)
        {
            surveyDBcontext.option_choices.Add(option);
            surveyDBcontext.SaveChanges();
        }

        public void DeleteOptionChoice(option_choices option)
        {
            surveyDBcontext.option_choices.Attach(option);
            surveyDBcontext.option_choices.Remove(option);
            surveyDBcontext.SaveChanges();
        }

        public List<option_choices> GetOptionsChoices(questions question)
        {
            return surveyDBcontext.option_choices.Where(x => x.Question_id == question.Id).ToList();
        }

        public void UpdateOptionsChoice(option_choices optionChoice, string newOptionChoiceName)
        {
            optionChoice.Option_choices_name = newOptionChoiceName;
            surveyDBcontext.SaveChanges();
        }
    }
}
