using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Interface
{
    interface ITextAnswers
    {
        void AddTextAnswer(text_answers answer);

        void DeleteTextAnswer(text_answers answer);

        List<text_answers> GetTextAnswers(questions question);
    }
}
