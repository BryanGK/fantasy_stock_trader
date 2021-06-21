using Core.DbServices;
using Core.Entities;
using Core.Services;
using Infrastructure.Exceptions;
using NSubstitute;
using NUnit.Framework;

namespace fantasy_stock_trader.Tests.Services
{
    [TestFixture]
    public class TransServiceTests
    {
        private IWalletQueryService _walletQueryService;
        private ITransactionQueryService _transactionQueryService;
        private TransactionService _sut;

        [SetUp]
        public void SetUp()
        {
            _walletQueryService = Substitute.For<IWalletQueryService>();

            _transactionQueryService = Substitute.For<ITransactionQueryService>();

            _sut = new TransactionService(_walletQueryService, _transactionQueryService);
        }

        [Test]
        public void Buy_CashIsGreaterThanTotalPrice_ReturnsWallet()
        {
            var wallet = new WalletEntity() { Cash = 100.00M };

            _walletQueryService.GetWallet(Arg.Any<string>()).Returns(wallet);

            var result = _sut.Buy("9fefa208-5c52-4435-a3ca-70d1e9cee692", "V", 10.00M, 1);

            Assert.That(result.Cash, Is.EqualTo(100.00M));
        }

        [Test]
        public void Buy_CashIsLessThanTotalPrice_ThrowsInsufficientAvailableFundsException()
        {
            var wallet = new WalletEntity() { Cash = 100.00M };

            _walletQueryService.GetWallet(Arg.Any<string>()).Returns(wallet);

            Assert.Throws<InsufficientAvailableFundsException>(() => _sut.Buy("9fefa208-5c52-4435-a3ca-70d1e9cee692", "V", 101.00M, 1));
        }

        [Test]
        public void Sell_WhenCalled_ReturnsWallet()
        {
            var wallet = new WalletEntity() { Cash = 100.00M };

            _walletQueryService.GetWallet(Arg.Any<string>()).Returns(wallet);

            var result = _sut.Sell("9fefa208-5c52-4435-a3ca-70d1e9cee692", "V", 10.00M, 1);

            Assert.That(result.Cash, Is.EqualTo(100.00M));
        }
    }
}
