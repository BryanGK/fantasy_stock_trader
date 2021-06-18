using Core.DbServices;
using Core.Entities;
using Infrastructure.Exceptions;

namespace Core.Services
{

    public interface ITransactionService
    {
        WalletEntity Buy(string userId, string stock, decimal price, int quantity);

        WalletEntity Sell(string userId, string stock, decimal price, int quantity);
    }

    public class TransactionService : ITransactionService
    {
        private readonly IWalletQueryService _walletQueryService;
        private readonly ITransactionQueryService _transactionQueryService;

        public TransactionService(IWalletQueryService walletQueryService, ITransactionQueryService transactionQueryService)
        {
            _walletQueryService = walletQueryService;
            _transactionQueryService = transactionQueryService;
        }

        public WalletEntity Buy(string userId, string stock, decimal price, int quantity)
        {
            var isPurchase = true;

            decimal totalPrice = price * quantity;

            var wallet = _walletQueryService.GetWallet(userId);

            if (wallet.Cash >= totalPrice)
            {
                _walletQueryService.Update(wallet.WalletId, totalPrice, isPurchase);

                _transactionQueryService.AddTransaction(userId, stock, price, quantity);
            }
            else
                throw new InsufficientAvailableFundsException("There are insufficient funds to complete this transaction.");

            return wallet;

        }

        public WalletEntity Sell(string userId, string stock, decimal price, int quantity)
        {
            var isPurchase = false;

            decimal totalPrice = price * quantity;

            quantity = -quantity;

            var wallet = _walletQueryService.GetWallet(userId);

            _walletQueryService.Update(wallet.WalletId, totalPrice, isPurchase);

            _transactionQueryService.AddTransaction(userId, stock, price, quantity);

            return wallet;
        }
    }
}
