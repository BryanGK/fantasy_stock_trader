using System;
namespace Core.Mappings
{
    public class UserWalletModel
    {
        public virtual Guid Wallet_Id { get; set; }

        public virtual string User_Id { get; set; }

        public virtual decimal Cash { get; set; }
    }
}
