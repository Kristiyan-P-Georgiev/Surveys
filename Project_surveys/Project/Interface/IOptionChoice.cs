using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Interface
{
    interface IOptionChoice
    {
        void AddOptionChoice(option_choices option);

        List<option_choices> GetOptionsChoices(questions question);

        void DeleteOptionChoice(option_choices option);

        void UpdateOptionsChoice(option_choices optionChoice, string newOptionChoiceName);
    }
}
