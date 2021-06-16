using System;
using Core.Services;
using NSubstitute;
using NUnit.Framework;

namespace fantasy_stock_trader.Tests.Services
{
    [TestFixture]
    public class HoldingsServiceTests
    {
        private ITransactionQueryService _transactionQueryService;
        private IHoldingsProcessor _holdingsProcessor;
        private IStockService _stockService;
        private IWalletQueryService _walletQueryService;
        private HoldingsService _sut;

        [SetUp]
        public void SetUp()
        {
            _transactionQueryService = Substitute.For<ITransactionQueryService>();
            _holdingsProcessor = Substitute.For<IHoldingsProcessor>();
            _stockService = Substitute.For<IStockService>();
            _walletQueryService = Substitute.For<IWalletQueryService>();
            _sut = new HoldingsService(_transactionQueryService,
                _holdingsProcessor,
                _stockService,
                _walletQueryService);
        }

        [Test]
        public void GetHoldings_TransactionCountIsGreaterThanZero_ReturnsHoldings()
        {

        }

        [Test]
        public void GetHoldings_TransactionCountIsZeroOrLess_ReturnsHoldings()
        {

        }
    }
}
