using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface ILoginService
    {
        UserSession GetUserByName(string username, string password);

        UserSession GetUserById(string userId);
    }

    public class LoginService : ILoginService
    {
        private readonly ISessionFactory _factory;

        public LoginService(ISessionFactory factory)
        {
            _factory = factory;
        }

        public UserSession GetUserByName(string username, string password)
        {
            using (var session = _factory.OpenSession())
            {
                var user = session.Query<UserEntity>().FirstOrDefault(x => x.Username == username);

                if (user == null)
                    throw new Exception("User does not exist");

                if (user.Password != password)
                    throw new Exception("Password does not match");

                var userSession = new UserSession()
                {
                    UserId = user.UserId.ToString(),
                    SessionId = Guid.NewGuid()
                };

                return userSession;
            }
        }

        public UserSession GetUserById(string userId)
        {
            Guid userIdGuid = Guid.Parse(userId);

            using (var session = _factory.OpenSession())
            {
                var user = session.Get<UserEntity>(userIdGuid);

                var userSession = new UserSession()
                {
                    UserId = user.UserId.ToString(),
                    SessionId = Guid.NewGuid()
                };

                return userSession;
            }
        }
    }
}
