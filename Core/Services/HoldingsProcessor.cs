using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.IEXModels;
using Core.Models;

namespace Core.Services
{
    public interface IHoldingsProcessor
    {

        public List<Holding> HoldingsCombiner(List<TransactionEntity> transactions, Dictionary<string, LatestPriceModel> quote);

        public List<Transaction> Transactions(List<TransactionEntity> transactions);

        public decimal HoldingsValue(List<Holding> holdings);

    }

    public class HoldingsProcessor : IHoldingsProcessor
    {

        public List<Holding> HoldingsCombiner(List<TransactionEntity> transactions, Dictionary<string, LatestPriceModel> quote)
        {

            var combinedHoldings = new List<Holding>();

            foreach (var transaction in transactions)
            {
                var latestPrice = quote[transaction.Stock].Quote.LatestPrice;

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

        public List<Transaction> Transactions(List<TransactionEntity> transactions)
        {
            var transactionList = new List<Transaction>();

            foreach (var trans in transactions)
            {
                var transaction = new Transaction()
                {
                    TransactionId = trans.TransactionId,
                    UserId = trans.UserId,
                    Stock = trans.Stock,
                    Price = trans.Price,
                    Quantity = trans.Quantity,
                    Date = trans.Date
                };

                transactionList.Add(transaction);
            }

            return transactionList;
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
