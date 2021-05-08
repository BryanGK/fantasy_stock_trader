using System;
namespace API.Models
{
    public class UserWallet
    {
        public Guid UserId { get; set; }

        public decimal Cash { get; set; }
    }
}
