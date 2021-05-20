using System;

namespace Core.Entities
{
    public class UserEntity
    {
        public virtual Guid UserId { get; set; }

        public virtual string Username { get; set; }

        public virtual string Password { get; set; }
    }
}
