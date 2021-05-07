using System;
namespace API.Models
{
    public class TransModel
    {
        public Guid TransactionId { get; set; }

        public Guid UserId { get; set; }

        public string Stock { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string CreatedOn { get; set; }
    }
}
