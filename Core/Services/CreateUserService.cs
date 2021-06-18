using Core.DbServices;
using Core.Entities;
using Infrastructure.Exceptions;

namespace Core.Services
{
    public interface ICreateUserService
    {
        UserEntity CreateUser(string username, string password);

        string CreateWallet(string userId);
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

        public UserEntity CreateUser(string username, string password)
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

        public string CreateWallet(string userId)
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
                return userId;
            }
            else
            {
                throw new UserAlreadyExistsException($"Error in creating wallet");
            }
        }
    }
}

