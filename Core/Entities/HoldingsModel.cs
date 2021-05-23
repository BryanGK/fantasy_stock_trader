using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public class HoldingsModel
    {
        public virtual decimal Value { get; set; }

        public virtual decimal Cash { get; set; }

        public List<Holding> Holdings { get; set; }
    }


    public class Holding
    {
        public virtual string Stock { get; set; }

        public virtual decimal Price { get; set; }

        public virtual decimal LatestPrice { get; set; }

        public virtual decimal TotalPrice { get; set; }

        public virtual int Quantity { get; set; }
    }
}
