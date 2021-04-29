using System;
using System.Threading.Tasks;
using API.Models;
using Npgsql;

namespace API.Services
{
    public interface IAuthService
    {
        Task<UserModel> GetUserDb(string username, string password);

        Task<bool> DoesUserExist(string username);
    }

    public class AuthService : IAuthService
    {

        public async Task<UserModel> GetUserDb(string username, string password)
        {
            UserModel user = new UserModel();

            var connString = "Host=localhost;Port=5432;Username=bryankrauss;Password=password123;Database=fantasy_stock_users";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand($"SELECT user_id, username, password, email FROM users WHERE username = (@p);", conn);
            cmd.Parameters.AddWithValue("p", username);
            cmd.ExecuteNonQuery();
            await using var reader = await cmd.ExecuteReaderAsync();
            while (reader.Read())
            {
                if (password == reader.GetString(reader.GetOrdinal("password")))
                {
                    user.User_Id = reader.GetGuid(reader.GetOrdinal("user_id"));
                    user.Username = reader.GetString(reader.GetOrdinal("username"));
                    user.Email = reader.GetString(reader.GetOrdinal("email"));
                    return user;
                }
                else
                    return user;
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
