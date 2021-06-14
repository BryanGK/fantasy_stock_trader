using System;
using Core.Entities;
using Core.Models;
using Core.Services;
using Infrastructure.Exceptions;
using NSubstitute;
using NUnit.Framework;

namespace fantasy_stock_trader.Tests.Services
{
    [TestFixture]
    public class LoginServiceTests
    {
        private IDbQueryService _dbQueryService;
        private LoginService _sut;

        [SetUp]
        public void Setup()
        {
            _dbQueryService = Substitute.For<IDbQueryService>();

            _sut = new LoginService(_dbQueryService);
        }

       [Test]
       public void CreateSessionByUsername_UserIsNull_ThrowsUserNotFoundException()
        {
            var user = new UserEntity();

            _dbQueryService.GetUser(Arg.Any<string>()).Returns(user);

            Assert.Throws<UserNotFoundException>(() => _sut.CreateSessionByUsername("bryan", "pwd123"));
        }

        [Test]
        public void CreateSessionByUsername_NotValidPassword_ThrowsUserNotFoundException()
        {
            var user = new UserEntity()
            {
                Password = "pwd"
            };

            _dbQueryService.GetUser(Arg.Any<string>()).Returns(user);

            Assert.Throws<UserNotFoundException>(() => _sut.CreateSessionByUsername("bryan", "pwd123"));
        }

        [Test]
        public void CreateSessionByUsername_ValidUsernameAndPassword_ReturnsUserSession()
        {
            var user = new UserEntity()
            {
                Username = "bryan",
                Password = "pwd123"
            };

            _dbQueryService.GetUser(Arg.Any<string>()).Returns(user);

            var result = _sut.CreateSessionByUsername("bryan", "pwd123");

            Assert.That(result, Is.TypeOf<UserSession>());
        }

        [Test]
        public void CreateSessionByUserId_WhenCalled_ReturnsUserSession()
        {
            var user = new UserEntity();

            _dbQueryService.GetUser(Arg.Any<string>()).Returns(user);

            var result = _sut.CreateSessionByUserId(Guid.NewGuid().ToString());

            Assert.That(result, Is.TypeOf<UserSession>());
        }
    }
}
