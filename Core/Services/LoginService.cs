using System;
using System.Linq;
using Core.Entities;
using Core.Models;
using NHibernate;
using Infrastructure.Exceptions;

namespace Core.Services
{
    public interface ILoginService
    {
        UserSession GetUserByName(string username, string password);

        UserSession GetUserById(string userId);
    }

    public class LoginService : ILoginService
    {
        private readonly IUserQueryService _userQueryService;

        public LoginService(IUserQueryService queryService)
        {
            _userQueryService = queryService;
        }

        public UserSession GetUserByName(string username, string password)
        {
            var user = _userQueryService.GetUser(username);

            if (user == null || user.Password != password)
                throw new UserNotFoundException("Incorrect username or password, please try again.");

            var userSession = new UserSession()
            {
                UserId = user.UserId.ToString(),
                SessionId = Guid.NewGuid(),
                Username = user.Username
            };

            return userSession;
        }

        public UserSession GetUserById(string userId)
        {
            var user = _userQueryService.GetUser(Guid.Parse(userId));

            var userSession = new UserSession()
            {
                UserId = user.UserId.ToString(),
                SessionId = Guid.NewGuid(),
                Username = user.Username
            };

            return userSession;
        }
    }
}
