using System;
namespace Core.Models
{
    public class UserModel
    {
        public virtual Guid UserId { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }
    }
}
