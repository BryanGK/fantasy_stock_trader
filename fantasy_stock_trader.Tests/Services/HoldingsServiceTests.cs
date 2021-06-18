using System.Collections.Generic;
using System.Threading.Tasks;
using Core.DbServices;
using Core.Entities;
using Core.Models;
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
            var transactions = new List<TransactionEntity>();
            transactions.Add(new TransactionEntity() { Price = 1.00M, Quantity = 1, Stock = "v"});
            transactions.Add(new TransactionEntity() { Price = 5.00M, Quantity = 1, Stock = "tsla"});
            transactions.Add(new TransactionEntity() { Price = 10.00M, Quantity = 1, Stock = "goog"});

            //var latestPrice = new Dictionary<string, LatestPriceModel>();
            //latestPrice.Add("v", new LatestPriceModel() { Quote = new QuoteModel() { LatestPrice = 10.00M} });
            //latestPrice.Add("tsla", new LatestPriceModel() { Quote = new QuoteModel() { LatestPrice = 50.00M} });
            //latestPrice.Add("goog", new LatestPriceModel() { Quote = new QuoteModel() { LatestPrice = 100.00M} });

            //var processedHoldings = new List<Holding>();
            //processedHoldings.Add(new Holding() { Stock = "v", LatestPrice = 10.00M, Quantity = 1 });
            //processedHoldings.Add(new Holding() { Stock = "tsla", LatestPrice = 50.00M, Quantity = 1 });
            //processedHoldings.Add(new Holding() { Stock = "goog", LatestPrice = 100.00M, Quantity = 1 });

            //var holdingsValue = 160.00M;

            //var cash = new WalletEntity() { Cash = 100.00M };


            _transactionQueryService.GetTransactions(Arg.Any<string>()).Returns(transactions);

            //_stockService.LatestPrice(Arg.Any<List<TransactionEntity>>()).Returns(latestPrice);

            //_holdingsProcessor.HoldingsCombiner(Arg.Any<List<TransactionEntity>>(),
            //    Arg.Any<Dictionary<string, LatestPriceModel>>()).Returns(processedHoldings);

            //_holdingsProcessor.HoldingsValue(Arg.Any<List<Holding>>()).Returns(holdingsValue);

            //_walletQueryService.GetWallet(Arg.Any<string>()).Returns(cash);

            var result = _sut.GetHoldings("9fefa208-5c52-4435-a3ca-70d1e9cee692");

            Assert.That(result, Is.TypeOf<Task<TotalHoldings>>());
        }

        [Test]
        public void GetHoldings_TransactionCountIsZeroOrLess_ReturnsHoldings()
        {
            var transactions = new List<TransactionEntity>();

            _transactionQueryService.GetTransactions(Arg.Any<string>()).Returns(transactions);

            var result = _sut.GetHoldings("9fefa208-5c52-4435-a3ca-70d1e9cee692");

            Assert.That(result, Is.TypeOf<Task<TotalHoldings>>());
        }
    }
}
