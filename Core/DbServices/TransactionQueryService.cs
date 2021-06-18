using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.DbServices
{
    public interface ITransactionQueryService
    {
        List<TransactionEntity> GetTransactions(string userId);
        void AddTransaction(string userId, string stock, decimal price, int quantity);
    }

    public class TransactionQueryService : ITransactionQueryService
    {
        private readonly ISessionFactory _factory;

        public TransactionQueryService(ISessionFactory factory)
        {
            _factory = factory;
        }

        public List<TransactionEntity> GetTransactions(string userId)
        {
            using (var session = _factory.OpenSession())
            {
                var holdings = session.Query<TransactionEntity>().Where(x => x.UserId == userId).OrderBy(holdings => holdings.Stock).ToList();

                return holdings;
            }
        }

        public void AddTransaction(string userId, string stock, decimal price, int quantity)
        {
            using (var session = _factory.OpenSession())
            {
                var transaction = new TransactionEntity()
                {
                    UserId = userId,
                    Stock = stock,
                    Price = price,
                    Quantity = quantity,
                    Date = DateTime.Now
                };

                session.Save(transaction);

                session.Flush();
            }
        }
    }
}
