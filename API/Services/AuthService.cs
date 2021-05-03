using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using NHibernate;
using Npgsql;

namespace API.Services
{
    public interface IAuthService
    {
        IEnumerable<UserModel> GetUserDb(string username);

        Task<bool> DoesUserExist(string username);
    }

    public class AuthService : IAuthService
    {

        private readonly IAuthService _authService;
        private readonly ISessionFactory _factory;

        //public AuthService(IAuthService authService)
        //{
        //    _authService = authService;

        //}

        public AuthService(ISessionFactory factory)
        {
            _factory = factory;

        }

        public IEnumerable<UserModel> GetUserDb(string username)
        {
            using (var session = _factory.OpenSession())

            {
                var query = session.Query<UserModel>()
                                   .Where(c => c.Username == username)
                                   .ToList();
                return query;
            }

            throw new Exception();
        }

        public async Task<bool> DoesUserExist(string username)
        {
            var connString = "Host=localhost;Port=5432;Username=bryankrauss;Password=password123;Database=fantasy_stock_users";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand("SELECT * FROM users WHERE EXISTS (SELECT * FROM users WHERE username = (@p));", conn);
            cmd.Parameters.AddWithValue("p", username);
            cmd.ExecuteNonQuery();
            await using var reader = await cmd.ExecuteReaderAsync();

            return reader.HasRows;
        }
    }
}
