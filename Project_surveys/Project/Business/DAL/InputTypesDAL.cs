using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Interface;
using Project.Data;

namespace Project.Business.DAL
{
    public class InputTypesDAL : IInputType
    {
        public surveysdbEntities1 surveyDBcontext = Database.GetConnection();

        public string GetInputTypeName(questions question)
        {
            input_types inputType = surveyDBcontext.input_types.Where(x => x.Id == question.Input_type_id).FirstOrDefault();
            return inputType.Input_type_name;
        }
    }
}
