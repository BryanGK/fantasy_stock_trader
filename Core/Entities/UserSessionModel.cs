using System;
namespace Core.Entities
{
    public class UserSession
    {
        public virtual string UserId { get; set; }

        public virtual Guid SessionId { get; set; }
    }
}
