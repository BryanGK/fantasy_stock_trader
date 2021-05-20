using System;
namespace Core.Entities
{
    public class WalletEntity
    {
        public virtual Guid WalletId { get; set; }

        public virtual string UserId { get; set; }

        public virtual decimal Cash { get; set; }
    }
}
