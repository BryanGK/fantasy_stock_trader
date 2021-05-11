using System;
namespace API.Models
{
    public class TransModel
    {
        public virtual Guid TransactionId { get; set; }

        public virtual Guid UserId { get; set; }

        public virtual string Stock { get; set; }

        public virtual decimal Price { get; set; }

        public virtual int Quantity { get; set; }

    }
}
