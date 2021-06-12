using System;
using NUnit.Framework;

namespace fantasy_stock_trader.Tests.Services
{
    [TestFixture]
    public class LoginServiceTests
    {
       [Test]
       public void GetUserByName_UserIsNull_ThrowsUserNotFoundException()
        {

        }

        [Test]
        public void GetUserByName_NotValidPassword_ThrowsUserNotFoundException()
        {

        }

        [Test]
        public void GetUserByName_ValidUsernameAndPassword_ReturnsUserSession()
        {

        }
    }
}
