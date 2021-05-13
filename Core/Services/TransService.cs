using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{

    public interface ITransService
    {
        UserWalletModel Buy(TransactionModel transModel);
    }

    public class TransService : ITransService
    {

        private readonly ISessionFactory _sessionFactory;

        public TransService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public UserWalletModel Buy(TransactionModel transModel)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var transaction = new TransactionModel()
                {
                    UserId = transModel.UserId,
                    Stock = transModel.Stock,
                    Price = transModel.Price,
                    Quantity = transModel.Quantity,
                };

                session.Save(transaction);

                var wallet = session.Query<UserWalletModel>().FirstOrDefault(x => x.User_Id == transModel.UserId);

                return wallet;
            }
        }
    }
}
