using System;
using System.Linq;
using API.Models;
using NHibernate;

namespace API.Services
{

    public interface ITransService
    {
        UserWalletModel Buy(TransactionInputModel transModel);
    }

    public class TransService : ITransService
    {

        private readonly ISessionFactory _sessionFactory;

        public TransService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public UserWalletModel Buy(TransactionInputModel transModel)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var transaction = new TransactionInputModel()
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
