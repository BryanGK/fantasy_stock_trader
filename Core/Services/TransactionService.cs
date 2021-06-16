using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{

    public interface ITransactionService
    {
        WalletEntity Buy(string userId, string stock, decimal price, int quantity);

        WalletEntity Sell(string userId, string stock, decimal price, int quantity);
    }

    public class TransactionService : ITransactionService
    {

        private readonly ISessionFactory _sessionFactory;

        public TransactionService(ISessionFactory sessionFactory)
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
                        Date = DateTime.Now
                    };

                    session.Save(transaction);

                    session.Flush();
                }

                return wallet;
            }
        }

        public WalletEntity Sell(string userId, string stock, decimal price, int quantity)
        {
            decimal totalPrice = price * quantity;

            using(var session = _sessionFactory.OpenSession())
            {
                var wallet = session.Query<WalletEntity>().FirstOrDefault(x => x.UserId == userId);

                wallet.Cash += totalPrice;

                session.Update(wallet);

                var transaction = new TransactionEntity()
                {
                    UserId = userId,
                    Stock = stock,
                    Price = price,
                    Quantity = -(quantity),
                    Date = DateTime.Now
                };

                session.Save(transaction);

                session.Flush();

                return wallet;
            }
        }
    }
}
