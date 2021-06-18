using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.DbServices
{
    public interface IWalletQueryService
    {
        WalletEntity GetWallet(string userId);
        void Save(WalletEntity wallet);
        void Update(Guid guid, decimal totalPrice, bool isPurchase);
    }
    public class WalletQueryService : IWalletQueryService
    {
        private readonly ISessionFactory _factory;

        public WalletQueryService(ISessionFactory factory)
        {
            _factory = factory;
        }

        public WalletEntity GetWallet(string userId)
        {
            using (var session = _factory.OpenSession())
            {
                return session.Query<WalletEntity>().FirstOrDefault(x => x.UserId == userId);
            }
        }

        public void Save(WalletEntity wallet)
        {
            using (var session = _factory.OpenSession())
            {
                session.Save(wallet);
            }
        }

        public void Update(Guid walletId, decimal totalPrice, bool isPurchase)
        {
            using (var session = _factory.OpenSession())
            {
                var updatingWallet = session.Load<WalletEntity>(walletId);

                if (isPurchase)
                    updatingWallet.Cash -= totalPrice;

                if (!isPurchase)
                    updatingWallet.Cash += totalPrice;

                session.Flush();
            }
        }
    }
}
