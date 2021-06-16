namespace Core.IEXModels
{
    public class QuoteModel
    {
        public string Symbol { get; set; }

        public string CompanyName { get; set; }

        public string PrimaryExchange { get; set; }

        public decimal LatestPrice { get; set; }

        public decimal PreviousClose { get; set; }

        public double Change { get; set; }

        public double ChangePercent { get; set; }

        public decimal Week52High { get; set; }

        public decimal Week52Low { get; set; }
    }
}
