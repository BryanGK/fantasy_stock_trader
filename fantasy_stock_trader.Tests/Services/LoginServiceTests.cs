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
        private ISessionFactory _sessionFactory;
        private LoginService _sut;

        [SetUp]
        public void Setup()
        {
            _sessionFactory = Substitute.For<ISessionFactory>();

            _sut = new LoginService(_sessionFactory);
        }

       [Test]
       public void GetUserByName_UserIsNull_ThrowsUserNotFoundException()
        {

        }

        [Test]
        public void GetUserByName_NotValidPassword_ThrowsUserNotFoundException()
        {
            var session = Substitute.For<ISession>();

            _sessionFactory.OpenSession().Returns(session);

            var user = new UserEntity()
            {
                Password = "pw"
            };

            var queryable = Substitute.For<IQueryable<UserEntity>>();
            queryable.FirstOrDefault(Arg.Any<Expression<Func<UserEntity, bool>>>()).Returns(user);
            session.Query<UserEntity>().Returns(queryable);

            Assert.Throws<UserNotFoundException>(() => _sut.GetUserByName("bryan", "pwd123"));
        }

        [Test]
        public void GetUserByName_ValidUsernameAndPassword_ReturnsUserSession()
        {

        }
    }
}
