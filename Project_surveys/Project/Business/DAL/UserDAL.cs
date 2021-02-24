using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Interface;
using Project.Data;

namespace Project.Business.DAL
{
    public class UserDAL : IUser
    {
        public surveysdbEntities1 surveyDBcontext = Database.GetConnection();

        public void AddUser(users user)
        {
            surveyDBcontext.users.Add(user);
            surveyDBcontext.SaveChanges();
        }

        public void DeleteUserByName(string name)
        {
            users user = GetUserByName(name);
            surveyDBcontext.users.Attach(user);
            surveyDBcontext.users.Remove(user);
            surveyDBcontext.SaveChanges();
        }

        public List<users> GetAllUsers()
        {
            return surveyDBcontext.users.ToList();
        }

        public users GetUserByName(string name)
        {
            return surveyDBcontext.users.Where(z => z.User_name == name).FirstOrDefault();
        }

        public void UpdateUser(users user, string newPassword)
        {
            user.User_password = newPassword;
            surveyDBcontext.SaveChanges();
        }
    }
}
