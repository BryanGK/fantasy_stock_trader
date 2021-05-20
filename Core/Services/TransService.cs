using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{

    public interface ITransService
    {
        WalletEntity Buy(string userId, string stock, decimal price, int quantity);
    }

    public class TransService : ITransService
    {

        private readonly ISessionFactory _sessionFactory;

        public TransService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public WalletEntity Buy(string userId, string stock, decimal price, int quantity)
        {
            decimal totalPrice = price * quantity;

            using (var session = _sessionFactory.OpenSession())
            {
                var wallet = session.Query<WalletEntity>().FirstOrDefault(x => x.UserId == userId);

                if (wallet.Cash >= totalPrice)
                {

                    var updatingWallet = session.Load<WalletEntity>(wallet.WalletId);

                    updatingWallet.Cash -= totalPrice;

                    session.Update(updatingWallet);

                    var transaction = new TransactionEntity()
                    {
                        UserId = userId,
                        Stock = stock,
                        Price = price,
                        Quantity = quantity,
                    };

                    session.Save(transaction);

                    session.Flush();
                }

                return wallet;
            }
        }
    }
}
