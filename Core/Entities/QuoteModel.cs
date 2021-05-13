﻿using System;
namespace Core.Entities
{
    public class QuoteModel
    {
        public string symbol { get; set; }

        public string companyName { get; set; }

        public string primaryExchange { get; set; }

        public double latestPrice { get; set; }

        public double previousClose { get; set; }

        public double change { get; set; }

        public double changePercent { get; set; }

        public double week52High { get; set; }

        public double week52Low { get; set; }
    }
}
