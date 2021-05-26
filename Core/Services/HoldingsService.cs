using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface IHoldingsService
    {
        List<TransactionEntity> GetTransactions(string userId);

        WalletEntity GetWallet(string userId);
    }

    public class HoldingsService : IHoldingsService
    {
        private readonly ISessionFactory _sessionFactory;

        public HoldingsService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<TransactionEntity> GetTransactions(string userId)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var holdings = session.Query<TransactionEntity>().Where(x => x.UserId == userId).OrderBy(holdings => holdings.Stock).ToList();

                return holdings;
            }

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
