using System;
namespace Core.Entities
{
    public class HoldingsModel
    {
        public virtual string Stock { get; set; }

        public virtual decimal Price { get; set; }

        public virtual int Quantity { get; set; }
    }
}
