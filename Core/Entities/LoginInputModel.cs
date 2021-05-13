using System;
namespace Core.Mappings
{
    public class LoginInputModel
    {
        public virtual Guid User_Id { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }
    }
}
