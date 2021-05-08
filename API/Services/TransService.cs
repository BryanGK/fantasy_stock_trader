using System;
using API.Models;
using NHibernate;

namespace API.Services
{

    public interface ITransService
    {
        UserWallet Buy(TransModel transModel);
    }

    public class TransService : ITransService
    {

        private readonly ISessionFactory _sessionFactory;

        public TransService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public UserWallet Buy(TransModel transModel)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var transaction = new TransModel()
                {
                    TransactionId = Guid.NewGuid(),
                    UserId = transModel.UserId,
                    Stock = transModel.Stock,
                    Price = transModel.Price,
                    Quantity = transModel.Quantity,
                };


            }
        }
    }
}
