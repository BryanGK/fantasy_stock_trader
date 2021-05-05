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
        LoginModel GetUserDb(string username, string password);
    }

    public class AuthService : IAuthService
    {
        private readonly ISessionFactory _factory;

        public AuthService(ISessionFactory factory)
        {
            _factory = factory;
        }

        public LoginModel GetUserDb(string username, string password)
        {
            using (var session = _factory.OpenSession())

            {
                var query = session.Query<LoginModel>()
                                   .FirstOrDefault(a => a.Username == username);
                                   
                return query;
            }

            throw new Exception();
        }
    }
}
