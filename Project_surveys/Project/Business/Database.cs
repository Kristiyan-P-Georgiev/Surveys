using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Business
{
    public static class Database
    {
        private static surveysdbEntities1 surveyDBcontext;

        public static surveysdbEntities1 GetConnection()
        {
            if (surveyDBcontext == null)
            {
                surveyDBcontext = new surveysdbEntities1();
            }

            return surveyDBcontext;
        }
    }
}
