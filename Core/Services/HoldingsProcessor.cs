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

        public decimal HoldingsValue(List<TransactionEntity> transactions); 

    }

    public class HoldingsProcessor : IHoldingsProcessor
    {

        public List<Holding> HoldingsCombiner(List<TransactionEntity> transactions, Dictionary<string, LatestPriceModel> quote)
        {

            var combinedHoldings = new List<Holding>();

            foreach (var transaction in transactions)
            {

                if (!combinedHoldings.Any(item => item.Stock == transaction.Stock))
                {

                    var holding = new Holding()
                    {
                        Stock = transaction.Stock,
                        Price = transaction.Price,
                        TotalPrice = transaction.Price * transaction.Quantity,
                        Quantity = transaction.Quantity,
                        LatestPrice = quote[transaction.Stock].Quote.latestPrice
                    };

                    combinedHoldings.Add(holding);
                }
                else
                {
                
                    var existingHolding = combinedHoldings.Find(item => item.Stock == transaction.Stock);

                    existingHolding.Quantity += transaction.Quantity;
                    existingHolding.TotalPrice += transaction.Price * transaction.Quantity;

                    if (existingHolding.Quantity <= 0)
                        combinedHoldings.Remove(existingHolding);

                }
            }

            return combinedHoldings;
        }

        public decimal HoldingsValue(List<TransactionEntity> transactions)
        {
            var TotalValue = 0M;

            foreach (var transaction in transactions)
            {
                TotalValue += transaction.Price * transaction.Quantity;
            }

            return TotalValue;
        }
    }
}
