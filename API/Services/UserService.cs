using System;
using System.Threading.Tasks;
using API.Models;
using Npgsql;

namespace API.Services
{
    public interface IUserService
    {
        Task<UserModel> CreateUser(string username, string email, string password);
    }

    public class UserService : IUserService
    {

        //private readonly IAuthService _authService;

        //public AuthController(IAuthService authService)
        //{
        //    _authService = authService;
        //}

        public async Task<UserModel> CreateUser(string username, string email, string password)
        {

            var existingUser = await DoesUserExist(username);

            if (!existingUser)
            {

                var connString = "Host=localhost;Port=5432;Username=bryankrauss;Password=password123;Database=fantasy_stock_users";

                await using var conn = new NpgsqlConnection(connString);
                await conn.OpenAsync();

                await using var cmd = new NpgsqlCommand($"INSERT INTO users (username, email, password) VALUES ((@u), (@e), (@p));", conn);
                cmd.Parameters.AddWithValue("u", username);
                cmd.Parameters.AddWithValue("e", email);
                cmd.Parameters.AddWithValue("p", password);
                cmd.ExecuteNonQuery();

                UserModel user = new();

                user = await GetUserDb(username, password);

                return user;
            }
            else
                throw new Exception("That user already exist");


            throw new Exception("Error creating user account");
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

        public async Task<UserModel> GetUserDb(string username, string password)
        {

            var connString = "Host=localhost;Port=5432;Username=bryankrauss;Password=password123;Database=fantasy_stock_users";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            await using var cmd = new NpgsqlCommand($"SELECT user_id, username, password, email FROM users WHERE username = (@p);", conn);
            cmd.Parameters.AddWithValue("p", username);
            cmd.ExecuteNonQuery();

            await using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                UserModel user = new();

                user.User_Id = reader.GetGuid(reader.GetOrdinal("user_id"));
                user.Username = reader.GetString(reader.GetOrdinal("username"));
                user.Email = reader.GetString(reader.GetOrdinal("email"));
                return user;
            }

            throw new Exception();
        }
    }
}
