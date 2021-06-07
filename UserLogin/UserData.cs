using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers;
        static public List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        static private void ResetTestUserData()
        {
            if (_testUsers == null || _testUsers.Count == 0)
            {
                _testUsers = new List<User>
                {
                    new User("user1", "1234", UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue),
                    new User("user2", "1234", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue),
                    new User("user3", "1234", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue),
                    new User("user4", "1234", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue)
                };
            }
        }

        static public User IsUserPassCorrect(String password)
        {
            UserContext context = new UserContext();
           return (from user in context.Users where user.Password == password select user).First();
        }

        static public void AssignUserRole(int userId, string role)
        {
            UserContext context = new UserContext();
            User user =
                (from u in TestUsers
                 where u.UserId == userId
                 select u).First();

            user.Role = role;
            context.SaveChanges();
        }

        static public void SetUserActiveTo(string username, DateTime activeTo)
        {
            foreach (User user in _testUsers)
            {
                if (user.Username.Equals(username))
                {
                    user.ActiveTo = activeTo;
                    Logger.LogActivity("Промяна на активност на " + username);
                    break;
                }
            }
        }

        static public string GetAllUsersAsText()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Потребители:");
            foreach (User user in _testUsers)
            {
                output.AppendLine(user.ToString());
            }
            return output.ToString();
        }
    }
}
