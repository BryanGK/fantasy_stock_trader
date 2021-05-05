using System;
namespace API.Models
{
    public class LoginModel
    {
        public virtual Guid User_Id { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }
    }
}
