﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Models;
using NHibernate;

namespace Core.Services
{
    public interface IHoldingsService
    {
        Task<HoldingsModel> GetHoldings(string userId);
    }

    public class HoldingsService : IHoldingsService
    {
        private readonly ITransactionQueryService _transactionQueryService;
        private readonly IHoldingsProcessor _holdingsProcessor;
        private readonly IStockService _stockService;
        private readonly IWalletQueryService _walletQueryService;

        public HoldingsService(ITransactionQueryService transactionQueryService,
            IHoldingsProcessor holdingsProcessor,
            IStockService stockService,
            IWalletQueryService walletQueryService)
        {
            _transactionQueryService = transactionQueryService;
            _holdingsProcessor = holdingsProcessor;
            _stockService = stockService;
            _walletQueryService = walletQueryService;
        }

        public async Task<HoldingsModel> GetHoldings(string userId)
        {
            var transactions = _transactionQueryService.GetTransactions(userId);

            if (transactions.Count > 0)
            {

                var latestPrice = await _stockService.LatestPrice(transactions);

                var processedHoldings = _holdingsProcessor.HoldingsCombiner(transactions, latestPrice);

                var holdingsValue = _holdingsProcessor.HoldingsValue(processedHoldings);

                var cash = _walletQueryService.GetWallet(userId);

                var holdings = new HoldingsModel()
                {
                    Cash = cash.Cash,
                    Value = holdingsValue,
                    Holdings = processedHoldings
                };

                return holdings;
            }
            else
            {
                var cash = _walletQueryService.GetWallet(userId);

                var holdings = new HoldingsModel()
                {
                    Cash = cash.Cash,
                };

                return holdings;
            }
        }
    }
}
