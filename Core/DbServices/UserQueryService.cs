using System;
using System.Linq;
using Core.Entities;
using NHibernate;

namespace Core.DbServices
{
    public interface IUserQueryService
    {
        UserEntity GetUser(string username);

        UserEntity GetUser(Guid id);

        UserEntity Save(UserEntity user);
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
                return session.Query<UserEntity>().FirstOrDefault(x => x.Username == username);
            }
        }

        public UserEntity GetUser(Guid id)
        {
            using (var session = _factory.OpenSession())
            {
                return session.Get<UserEntity>(id);
            }
        }

        public UserEntity Save(UserEntity user)
        {
            using (var session = _factory.OpenSession())
            {
                var UserId = session.Save(user);
                user.UserId = (Guid)UserId;
                return user;
            }
        }
    }
}
