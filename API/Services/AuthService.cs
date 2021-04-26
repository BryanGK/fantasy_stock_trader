using System;
using System.Threading.Tasks;
using API.Models;
using Npgsql;

namespace API.Services
{
    public interface IAuthService
    {
        Task<UserModel> GetUserDb(string username);
    }

    public class AuthService : IAuthService
    {
        public async Task<UserModel> GetUserDb(string username)
        {
            var connString = "Host=localhost;Port=5432;Username=bryankrauss;Password=password123;Database=fantasy_stock_users";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand($"SELECT id, username, password FROM users WHERE username = '{username}';", conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                UserModel user = new UserModel();
                user.Id = reader.GetString(reader.GetOrdinal("id"));
                user.Username = reader.GetString(reader.GetOrdinal("username"));
                user.Password = reader.GetString(reader.GetOrdinal("password"));
                return user;
            }

            throw new Exception();
        }
    }
}
