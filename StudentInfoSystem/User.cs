using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInfoSystem
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ActiveTo { get; set; }

        public virtual Student Student { get; set; }

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

        public User(Guid UserId, string Username, string Password, string Role, DateTime Created, DateTime? ActiveTo)
            : this(Username, Password, Role, Created, ActiveTo)
        {
            this.UserId = UserId;
        }
    }
}
