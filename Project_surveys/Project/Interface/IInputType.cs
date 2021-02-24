using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Interface
{
    interface IInputType
    {
        string GetInputTypeName(questions question);
    }
}
