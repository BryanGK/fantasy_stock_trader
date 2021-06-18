using System;
using Core.Models;
using Infrastructure.Exceptions;
using Core.DbServices;

namespace Core.Services
{
    public interface ILoginService
    {
        UserSession CreateSessionByUsername(string username, string password);

        UserSession CreateSessionByUserId(string userId);
    }

    public class LoginService : ILoginService
    {
        private readonly IUserQueryService _userQueryService;

        public LoginService(IUserQueryService dbQueryService)
        {
            _userQueryService = dbQueryService;
        }

        public UserSession CreateSessionByUsername(string username, string password)
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

        public UserSession CreateSessionByUserId(string userId)
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
