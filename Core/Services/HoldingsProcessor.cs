using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.IEXModels;

namespace Core.Services
{
    public interface IHoldingsProcessor
    {

        public List<Holding> HoldingsCombiner(List<TransactionEntity> transactions, Dictionary<string, LatestPriceModel> quote);

        public decimal HoldingsValue(List<Holding> holdings);

    }

    public class HoldingsProcessor : IHoldingsProcessor
    {

        public List<Holding> HoldingsCombiner(List<TransactionEntity> transactions, Dictionary<string, LatestPriceModel> quote)
        {

            var combinedHoldings = new List<Holding>();

            foreach (var transaction in transactions)
            {
                var latestPrice = quote[transaction.Stock].Quote.latestPrice;

                if (!combinedHoldings.Any(item => item.Stock == transaction.Stock))
                {

                    var holding = new Holding()
                    {
                        Stock = transaction.Stock,
                        Price = transaction.Price,
                        TotalPrice = latestPrice * transaction.Quantity,
                        Quantity = transaction.Quantity,
                        LatestPrice = latestPrice
                    };

                    combinedHoldings.Add(holding);
                }
                else
                {

                    var existingHolding = combinedHoldings.Find(item => item.Stock == transaction.Stock);

                    existingHolding.Quantity += transaction.Quantity;
                    existingHolding.TotalPrice += latestPrice * transaction.Quantity;

                }
            }

            combinedHoldings.RemoveAll(item => item.Quantity <= 0);

            return combinedHoldings;
        }

        public decimal HoldingsValue(List<Holding> holdings)
        {
            var TotalValue = 0M;

            foreach (var holding in holdings)
            {
                TotalValue += holding.LatestPrice * holding.Quantity;
            }

            return TotalValue;
        }
    }
}
