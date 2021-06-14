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
        UserSession CreateSessionByUsername(string username, string password);

        UserSession CreateSessionByUserId(string userId);
    }

    public class LoginService : ILoginService
    {
        private readonly IDbQueryService _dbQueryService;

        public LoginService(IDbQueryService dbQueryService)
        {
            _dbQueryService = dbQueryService;
        }

        public UserSession CreateSessionByUsername(string username, string password)
        {
            var user = _dbQueryService.GetUser(username);

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
            var user = _dbQueryService.GetUser(Guid.Parse(userId));

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
