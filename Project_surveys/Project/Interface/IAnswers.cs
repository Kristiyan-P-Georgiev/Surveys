using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Interface
{
    interface IAnswers
    {
        void AddAnswer(answers answer);

        void DeleteAnswer(answers answer);

        List<answers> GetAnswers(int optionId);
    }
}
