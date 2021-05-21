using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Core.Services
{
    public interface IHoldingsProcessor
    {

        public List<HoldingsModel> HoldingsCombiner(List<TransactionEntity> transactionEntity);

    }

    public class HoldingsProcessor : IHoldingsProcessor
    {

        public List<HoldingsModel> HoldingsCombiner(List<TransactionEntity> transactionEntity)
        {

            var combinedHoldings = new List<HoldingsModel>();

            foreach (var transaction in transactionEntity)
            {

                if (!combinedHoldings.Any(item => item.Stock == transaction.Stock))
                {

                    var holding = new HoldingsModel()
                    {
                        Stock = transaction.Stock,
                        Price = transaction.Price,
                        Quantity = transaction.Quantity
                    };

                    combinedHoldings.Add(holding);
                }
                else
                {
                    var existingHolding = combinedHoldings.Find(item => item.Stock == transaction.Stock);

                    existingHolding.Quantity += transaction.Quantity;
                }

            }

            return combinedHoldings;
        }
    }


}
