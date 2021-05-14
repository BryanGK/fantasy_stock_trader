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
                var user = session.Query<UserModel>().FirstOrDefault(x => x.Username == username);

                if (user == null)
                    throw new Exception("User does not exist");

                if (user.Password != password)
                    throw new Exception("Password does not match");

                var userSession = new UserSession()
                {
                    UserId = user.User_Id.ToString(),
                    SessionId = Guid.NewGuid()
                };

                return userSession;
            }

            throw new Exception();
        }

        public UserSession GetUserById(string userId)
        {
            using (var session = _factory.OpenSession())
            {
                var user = session.Get<AuthUserModel>(userId);
                Console.WriteLine($"\nUSER ID {userId}\n");
                var userSession = new UserSession()
                {
                    UserId = user.UserId,
                    SessionId = Guid.NewGuid()
                };

                return userSession;
            }
        }
    }
}
