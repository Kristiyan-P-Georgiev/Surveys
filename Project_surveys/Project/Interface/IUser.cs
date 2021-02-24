using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data;

namespace Project.Interface
{
    interface IUser
    {
        users GetUserByName(string name);

        List<users> GetAllUsers();

        void DeleteUserByName(string name);

        void AddUser(users user);

        void UpdateUser(users user, string newPassword);
    }
}
