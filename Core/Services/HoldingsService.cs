using System;
using System.Collections.Generic;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface IHoldingsService
    {
        List<TransactionEntity> Get(string userId);
    }

    public class HoldingsService : IHoldingsService
    {
        private readonly ISessionFactory _sessionFactory;

        public HoldingsService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<TransactionEntity> Get(string userId)
        {

            using (var session = _sessionFactory.OpenSession())
            {
                var holdings = session.Query<TransactionEntity>().Where(c => c.UserId == userId).OrderBy(holdings => holdings.Stock).ToList();

                return holdings;
            }

        }

    }
}
