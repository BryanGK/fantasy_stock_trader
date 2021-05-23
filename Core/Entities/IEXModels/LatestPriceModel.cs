using System;
using System.Collections.Generic;

namespace Core.Entities.IEXModels
{
    public class LatestPriceModel
    {
        public List<Dictionary<string, Company>> Company { get; set; }
    }

    public class Company
    {
        public decimal LatestPrice { get; set; }

        public string Symbol { get; set; }
    }
}
