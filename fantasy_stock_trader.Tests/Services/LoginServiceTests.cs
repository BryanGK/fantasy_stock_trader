using System;
using Core.DbServices;
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
        private IUserQueryService _userQueryService;
        private LoginService _sut;

        [SetUp]
        public void Setup()
        {
            _userQueryService = Substitute.For<IUserQueryService>();

            _sut = new LoginService(_userQueryService);
        }

       [Test]
       public void CreateSessionByUsername_UserIsNull_ThrowsUserNotFoundException()
        {
            var user = new UserEntity();

            _userQueryService.GetUser(Arg.Any<string>()).Returns(user);

            Assert.Throws<UserNotFoundException>(() => _sut.CreateSessionByUsername("bryan", "pwd123"));
        }

        [Test]
        public void CreateSessionByUsername_NotValidPassword_ThrowsUserNotFoundException()
        {
            var user = new UserEntity()
            {
                Password = "pwd"
            };

            _userQueryService.GetUser(Arg.Any<string>()).Returns(user);

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

            _userQueryService.GetUser(Arg.Any<string>()).Returns(user);

            var result = _sut.CreateSessionByUsername("bryan", "pwd123");

            Assert.That(result, Is.TypeOf<UserSession>());
        }

        [Test]
        public void CreateSessionByUserId_WhenCalled_ReturnsUserSession()
        {
            var user = new UserEntity();

            _userQueryService.GetUser(Arg.Any<string>()).Returns(user);

            var result = _sut.CreateSessionByUserId(Guid.NewGuid().ToString());

            Assert.That(result, Is.TypeOf<UserSession>());
        }
    }
}
