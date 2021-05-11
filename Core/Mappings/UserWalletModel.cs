using System;
namespace API.Models
{
    public class UserWalletModel
    {
        public virtual Guid Wallet_Id { get; set; }

        public virtual string User_Id { get; set; }

        public virtual decimal Cash { get; set; }
    }
}
