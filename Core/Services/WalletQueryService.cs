using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface IWalletQueryService
    {
        WalletEntity GetWallet(string userId);
        void Save(WalletEntity wallet);
        void UpdateBuy(Guid guid, decimal totalPrice);
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

        public void UpdateBuy(Guid walletId, decimal totalPrice)
        {
            using (var session = _factory.OpenSession())
            {
                var updatingWallet = session.Load<WalletEntity>(walletId);

                updatingWallet.Cash -= totalPrice;

                session.Update(updatingWallet);
            }
        }
    }
}
