using System;
namespace Core.Entities
{
    public class CreateUserModel
    {
        public virtual Guid User_Id { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }
    }
}
