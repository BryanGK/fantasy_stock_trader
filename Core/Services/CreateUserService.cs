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

        private readonly IWalletQueryService _walletQueryService;
        private readonly IUserQueryService _userQueryService;

        public CreateUserService(IWalletQueryService walletQueryService, IUserQueryService dbQueryService)
        {
            _walletQueryService = walletQueryService;
            _userQueryService = dbQueryService;
        }

        public UserEntity Create(string username, string password)
        {

            var createdUser = new UserEntity()
            {
                Username = username,
                Password = password
            };

            var user = _userQueryService.GetUser(username);

            if (user == null)
            {
                return _userQueryService.Save(createdUser);
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

            var user = _walletQueryService.GetWallet(userId);

            if (user == null)
            {
                _walletQueryService.Save(wallet);
            }
            else
            {
                throw new UserAlreadyExistsException($"Error in creating wallet");
            }
        }
    }
}

