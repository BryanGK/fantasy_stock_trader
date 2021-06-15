using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface ITransactionQueryService
    {
        List<TransactionEntity> GetTransactions(string userId);
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
    }
}
