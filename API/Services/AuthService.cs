using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using NHibernate;
using Npgsql;

namespace API.Services
{
    public interface IAuthService
    {
        UserSession GetUserByName(string username, string password);

        UserSession GetUserById(Guid userId);
    }

    public class AuthService : IAuthService
    {
        private readonly ISessionFactory _factory;

        public AuthService(ISessionFactory factory)
        {
            _factory = factory;
        }

        public UserSession GetUserByName(string username, string password)
        {
            using (var session = _factory.OpenSession())
            {
                var user = session.Query<LoginModel>().FirstOrDefault(x => x.Username == username);

                if (user == null)
                    throw new Exception("User does not exist");

                if (user.Password != password)
                    throw new Exception("Password does not match");

                var userSession = new UserSession()
                {
                    User_Id = user.User_Id,
                    Session_Id = Guid.NewGuid()
                };

                return userSession;
            }

            throw new Exception();
        }

        public UserSession GetUserById(Guid userId)
        {
            using (var session = _factory.OpenSession())
            {
                var user = session.Get<LoginModel>(userId);

                var userSession = new UserSession()
                {
                    User_Id = user.User_Id,
                    Session_Id = Guid.NewGuid()
                };

                return userSession;
            }
        }
    }
}
