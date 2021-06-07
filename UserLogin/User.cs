using System;

namespace UserLogin
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ActiveTo { get; set; }

        public User()
        {

        }

        public User(string Username, string Password, string Role, DateTime Created, DateTime? ActiveTo)
        {
            this.Username = Username;
            this.Password = Password;
            this.Role = Role;
            this.Created = Created;
            this.ActiveTo = ActiveTo;
        }

        public User(int UserId, string Username, string Password, string Role, DateTime Created, DateTime? ActiveTo)
            : this(Username, Password, Role, Created, ActiveTo)
        {
            this.UserId = UserId;
        }
    }
}
