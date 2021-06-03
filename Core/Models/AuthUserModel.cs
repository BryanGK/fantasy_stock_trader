using System;
namespace Core.Models
{
    public class AuthUserModel
    {
        public virtual string UserId { get; set; }

        public virtual Guid SessionId { get; set; }
    }
}
