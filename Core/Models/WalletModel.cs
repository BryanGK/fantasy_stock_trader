using System;
namespace Core.Models
{
    public class WalletModel
    {
        public virtual Guid WalletId { get; set; }

        public virtual string UserId { get; set; }

        public virtual decimal Cash { get; set; }
    }
}
