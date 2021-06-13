using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface IUserQueryService
    {
        UserEntity GetUser(string username);

        UserEntity GetUser(Guid id);
    }
    public class UserQueryService : IUserQueryService
    {
        private readonly ISessionFactory _factory;

        public UserQueryService(ISessionFactory factory)
        {
            _factory = factory;
        }

        public UserEntity GetUser(string username)
        {
            using (var session = _factory.OpenSession())
            {
                return session.Query<UserEntity>().FirstOrDefault(u => u.Username == username);
            }
        }

        public UserEntity GetUser(Guid id)
        {
            using (var session = _factory.OpenSession())
            {
                return session.Get<UserEntity>(id);
            }
        }
    }
}
