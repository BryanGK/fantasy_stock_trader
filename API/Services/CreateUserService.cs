﻿using System;
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
        Guid Wallet(Guid userId);
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

            var createUser = new CreateUserModel()
            {
                Username = username,
                Password = password
            };

            using (var session = _sessionFactory.OpenSession())
            {
                var user = session.Query<LoginModel>().FirstOrDefault(x => x.Username == username);

                if (user == null)
                {
                    var createSuccess = session.Save(createUser);

                    var userId = Wallet((Guid)createSuccess);

                    return userId;
                }
            }

            throw new Exception("Error creating user account");
        }

        public Guid Wallet(Guid userId)
        {
            var wallet = new UserWalletModel()
            {
                User_Id = userId,
                Cash = 100000.00M
            };

            using (var session = _sessionFactory.OpenSession())
            {
                var user = session.Query<UserWalletModel>().FirstOrDefault(x => x.User_Id == userId);

                if (user == null)
                {
                    session.Save(wallet);
                    return userId;
                }
            }

            throw new Exception("Error creating user account");
        }
    }
}
