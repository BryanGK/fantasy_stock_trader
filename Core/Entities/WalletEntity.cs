using System;
namespace Core.Entities
{
    public class WalletEntity
    {
        public virtual Guid Wallet_Id { get; set; }

        public virtual string User_Id { get; set; }

        public virtual decimal Cash { get; set; }
    }
}
