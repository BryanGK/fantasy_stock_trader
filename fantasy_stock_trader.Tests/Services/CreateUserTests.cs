using Core.Entities;
using Core.Services;
using Infrastructure.Exceptions;
using NSubstitute;
using NUnit.Framework;

namespace fantasy_stock_trader.Tests.Services
{
    [TestFixture]
    public class CreateUserTests
    {
        private IWalletQueryService _walletQueryService;
        private IUserQueryService _userQueryService;
        private CreateUserService _sut;

        [SetUp]
        public void SetUp()
        {
            _userQueryService = Substitute.For<IUserQueryService>();

            _walletQueryService = Substitute.For<IWalletQueryService>();

            _sut = new CreateUserService(_walletQueryService, _userQueryService);
        }

        [Test]
        public void CreateUser_UserDoesNotExist_ReturnsUserEntity()
        {
            UserEntity user = null;

            _userQueryService.GetUser(Arg.Any<string>()).Returns(user);

            _userQueryService.Save(Arg.Any<UserEntity>()).Returns(new UserEntity());

            var result = _sut.CreateUser("bryan", "password");

            Assert.That(result, Is.TypeOf<UserEntity>());
        }

        [Test]
        public void CreateUser_UserDoesExist_ThrowsUserAlreadyExistsException()
        {
            var user = new UserEntity()
            {
                Username = "bryan"
            };

            _userQueryService.GetUser(Arg.Any<string>()).Returns(user);

            Assert.Throws<UserAlreadyExistsException>(() => _sut.CreateUser("bryan", "password"));
        }

        [Test]
        public void CreateWallet_UserDoesNotExist_ReturnsUserId()
        {
            WalletEntity user = null;

            _walletQueryService.GetWallet(Arg.Any<string>()).Returns(user);

            _walletQueryService.Save(Arg.Any<WalletEntity>());

            var result = _sut.CreateWallet("9fefa208-5c52-4435-a3ca-70d1e9cee692");

            Assert.That(result, Is.EqualTo("9fefa208-5c52-4435-a3ca-70d1e9cee692"));
        }

        [Test]
        public void CreateWallet_UserDoesExist_ThrowsUserAlreadyExistsException()
        {
            var user = new WalletEntity()
            {
                UserId = "9fefa208-5c52-4435-a3ca-70d1e9cee692"
            };

            _walletQueryService.GetWallet(Arg.Any<string>()).Returns(user);

            Assert.Throws<UserAlreadyExistsException>(() => _sut.CreateWallet("9fefa208-5c52-4435-a3ca-70d1e9cee692"));
        }
    }
}
