using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.Services
{
    public interface IDbQueryService
    {
        UserEntity GetUser(string username);

        UserEntity GetUser(Guid id);
    }
    public class DbQueryService : IDbQueryService
    {
        private readonly ISessionFactory _factory;

        public DbQueryService(ISessionFactory factory)
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
