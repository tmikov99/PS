using System.Data.Entity;
using System.Linq;

namespace StudentInfoSystem
{
    public static class DatabaseUtils
    {
        private static readonly StudentInfoContext dbContext = new StudentInfoContext();
        public static bool IsUserPresent(string username)
        {
            return dbContext.Users.AnyAsync(user => user.Username == username).Result;
        }

        public static User GetUserByUsername(string username)
        {
            return (from user in dbContext.Users
             where user.Username == username
             select user).First();
        }
    }
}
