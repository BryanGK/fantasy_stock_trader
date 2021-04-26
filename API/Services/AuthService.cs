using System;
using System.Threading.Tasks;
using API.Models;
using Npgsql;

namespace API.Services
{
    public interface IAuthService
    {
        Task<UserModel> GetUserDb(string username, string password);
    }

    public class AuthService : IAuthService
    {
        public async Task<UserModel> GetUserDb(string username, string password)
        {
            UserModel user = new UserModel();

            var connString = "Host=localhost;Port=5432;Username=bryankrauss;Password=password123;Database=fantasy_stock_users";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand($"SELECT id, username, password FROM users WHERE username = (@p);", conn);
            cmd.Parameters.AddWithValue("p", username);
            cmd.ExecuteNonQuery();
            await using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                user.Id = reader.GetString(reader.GetOrdinal("id"));
                user.Username = reader.GetString(reader.GetOrdinal("username"));
                user.Password = reader.GetString(reader.GetOrdinal("password"));
                return user;
            }


            throw new Exception();
        }
    }
}
