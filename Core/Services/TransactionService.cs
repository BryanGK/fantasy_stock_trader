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
        private readonly IWalletQueryService _walletQueryService;
        private readonly ITransactionQueryService _transactionQueryService;

        public TransactionService(ISessionFactory sessionFactory,
            IWalletQueryService walletQueryService,
            ITransactionQueryService transactionQueryService)
        {
            _sessionFactory = sessionFactory;
            _walletQueryService = walletQueryService;
            _transactionQueryService = transactionQueryService;
        }

        public WalletEntity Buy(string userId, string stock, decimal price, int quantity)
        {
            decimal totalPrice = price * quantity;

            var wallet = _walletQueryService.GetWallet(userId);

            if (wallet.Cash >= totalPrice)
            {

                _walletQueryService.UpdateBuy(wallet.WalletId, totalPrice);

                _transactionQueryService.AddTransaction(userId, stock, price, quantity);

            }

            return wallet;

        }

        public WalletEntity Sell(string userId, string stock, decimal price, int quantity)
        {
            decimal totalPrice = price * quantity;

            using (var session = _sessionFactory.OpenSession())
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
