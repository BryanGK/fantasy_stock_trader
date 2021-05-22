﻿using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;

namespace Core.Services
{
    public interface IHoldingsProcessor
    {

        public List<Holding> HoldingsCombiner(List<TransactionEntity> transactions);

        public decimal HoldingsValue(List<TransactionEntity> transactions); 

    }

    public class HoldingsProcessor : IHoldingsProcessor
    {

        public List<Holding> HoldingsCombiner(List<TransactionEntity> transactions)
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
                        Quantity = transaction.Quantity
                    };

                    combinedHoldings.Add(holding);
                }
                else
                {
                    var existingHolding = combinedHoldings.Find(item => item.Stock == transaction.Stock);

                    existingHolding.Quantity += transaction.Quantity;
                    existingHolding.TotalPrice += transaction.Price * transaction.Quantity;
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