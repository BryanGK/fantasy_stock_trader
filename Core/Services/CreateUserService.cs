using System;
using System.Linq;
using Core.Entities;
using Infrastructure.Exceptions;
using NHibernate;

namespace Core.Services
{
    public interface ICreateUserService
    {
        UserEntity Create(string username, string password);
        void Wallet(string userId);
    }

    public class CreateUserService : ICreateUserService
    {

        private readonly ISessionFactory _sessionFactory;

        public CreateUserService(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public UserEntity Create(string username, string password)
        {

            var createdUser = new UserEntity()
            {
                Username = username,
                Password = password
            };

            using (var session = _sessionFactory.OpenSession())
            {
                var user = session.Query<UserEntity>().FirstOrDefault(x => x.Username == username);

                if (user == null)
                {
                    var UserId = session.Save(createdUser);
                    createdUser.UserId = (Guid)UserId;
                    return createdUser;
                }
            }

            throw new UserAlreadyExistsException($"The username '{username}' is not available, please try again.");
        }

        public void Wallet(string userId)
        {
            var wallet = new WalletEntity()
            {
                UserId = userId,
                Cash = 100000.00M
            };

            using (var session = _sessionFactory.OpenSession())
            {
                var user = session.Query<WalletEntity>().FirstOrDefault(x => x.UserId == userId);

                if (user == null)
                {
                    session.Save(wallet);
                }
            }

            throw new UserAlreadyExistsException($"Error in creating wallet");

        }
    }
}
