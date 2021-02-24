using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Project.Business.DAL;
using Project.Business;
using Project.Data;

namespace TestProject
{   [TestFixture]
    class UserDALTest
    {
        surveysdbEntities1 surveyDbContext;
        private UserDAL userDAL;
        private users user;
        private string userName = "firstName";
        private string password = "12345";
       // private string newName = "NewName";
        private string newPassword = "passsword";
        [SetUp]
        public void TestInit()
        {
            surveyDbContext = Database.GetConnection();
            userDAL = new UserDAL();
            user = new users();
            user.User_name = userName;
            user.User_password = password;
        }
        [Test]
        public void AddingUserToDataBase()
        {
            
            int count = HelperDAL.GetNumberOfUsers();
            this.userDAL.AddUser(this.user);
            int result = HelperDAL.GetNumberOfUsers();
            HelperDAL.DeleteUser(userName);
            Assert.AreNotSame(result, count, "Method isn't adding user to DataBase.");
        }
        [Test]
        public void UserNameShouldBeDifferent()
        {
            this.userDAL.AddUser(this.user);
            this.userDAL.UpdateUser(this.user, newPassword);
            string changedPassword = this.user.User_password;
            HelperDAL.DeleteUser(userName);
            Assert.That(newPassword, Is.EqualTo(changedPassword),"Password doesn't change");
           
        }
        [Test]
        public void DeleteUserNameFromDataBase()
        {
            HelperDAL.AddUser(this.user);
            this.userDAL.DeleteUserByName(userName);
          users user2 =  this.userDAL.GetUserByName(userName);
            Assert.That(user2, Is.Null, "User ins't deleted.");
           
        }
        [Test]
        public void ShouldGetUserSuccessfully()
        {
            this.userDAL.AddUser(user);
           
            users user2 =  this.userDAL.GetUserByName(userName);
            this.userDAL.DeleteUserByName(userName);

            Assert.That(user2, Is.EqualTo(user), "Cannot get user from DataBase.");
        }
        [Test]
        public void ShouldGetAllUsersSuccessfully()
        {
            int count = surveyDbContext.users.Count();
            List<users> users = this.userDAL.GetAllUsers().ToList();
            Assert.IsNotNull(users);
            Assert.That(count, Is.EqualTo(users.Count),"Cannot get all questions from DataBase.");
        }
    }
}
