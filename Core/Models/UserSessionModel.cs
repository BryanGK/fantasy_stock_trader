using System;
namespace Core.Models
{
    public class UserSession
    {
        public virtual string UserId { get; set; }

        public virtual Guid SessionId { get; set; }

        public virtual string Username { get; set; }
    }
}
