using System;
namespace API.Models
{
    public class UserWalletModel
    {
        public Guid UserId { get; set; }

        public decimal Cash { get; set; }
    }
}
