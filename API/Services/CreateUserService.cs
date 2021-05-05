using System;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using NHibernate;
using Npgsql;

namespace API.Services
{
    public interface ICreateUserService
    {
        Guid User(string username, string password);
    }

    public class CreateUserService : ICreateUserService
    {

        private readonly ISessionFactory _sessionFactory;

        public CreateUserService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Guid User(string username, string password)
        {
            using (var session = _sessionFactory.OpenSession())
            {
                var user = session.Query<LoginModel>().FirstOrDefault(x => x.Username == username);
                if (user == null)
                {
                    var createUser = new CreateUserModel()
                    {
                        Username = username,
                        Password = password
                    };

                    var createSuccess = session.Save(createUser);

                    return (Guid)createSuccess;

                }
            }

            throw new Exception("Error creating user account");
        }
    }
}
