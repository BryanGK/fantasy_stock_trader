using System;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities;
using Core.Services;
using Infrastructure.Exceptions;
using NHibernate;
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
       public void GetUserByName_UserIsNull_ThrowsUserNotFoundException()
        {
          
        }

        [Test]
        public void GetUserName_NotValidPassword_ThrowsUserNotFoundException()
        {
            var user = new UserEntity()
            {
                Password = "pwd"
            };

            _userQueryService.GetUser(Arg.Any<string>()).Returns(user);

            Assert.Throws<UserNotFoundException>(() => _sut.GetUserByName("bryan", "pwd123"));
        }

        [Test]
        public void GetUserByName_ValidUsernameAndPassword_ReturnsUserSession()
        {

        }
    }
}
