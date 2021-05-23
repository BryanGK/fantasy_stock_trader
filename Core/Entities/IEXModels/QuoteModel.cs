using System;
namespace Core.Entities.IEXModels
{
    public class QuoteModel
    {
        public string symbol { get; set; }

        public string companyName { get; set; }

        public string primaryExchange { get; set; }

        public decimal latestPrice { get; set; }

        public decimal previousClose { get; set; }

        public decimal change { get; set; }

        public decimal changePercent { get; set; }

        public decimal week52High { get; set; }

        public decimal week52Low { get; set; }
    }
}
