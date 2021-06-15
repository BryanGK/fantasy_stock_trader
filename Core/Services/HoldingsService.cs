using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface IHoldingsService
    {
        List<TransactionEntity> GetHoldings(string userId);

        WalletEntity GetWallet(string userId);
    }

    public class HoldingsService : IHoldingsService
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly ITransactionQueryService _transactionQueryService;

        public HoldingsService(ISessionFactory sessionFactory, ITransactionQueryService transactionQueryService)
        {
            _sessionFactory = sessionFactory;
            _transactionQueryService = transactionQueryService;
        }

        public List<TransactionEntity> GetHoldings(string userId)
        {
            return _transactionQueryService.GetTransactions(userId);
        }

        public WalletEntity GetWallet(string userId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var wallet = session.Query<WalletEntity>().FirstOrDefault(x => x.UserId == userId);

                return wallet;
            }
        }

    }
}
