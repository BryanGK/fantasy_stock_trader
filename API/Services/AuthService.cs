using System;
using System.Threading.Tasks;
using API.Models;
using Npgsql;

namespace API.Services
{
    public interface IAuthService
    {
        Task<string> GetUserDb();
    }

    public class AuthService : IAuthService
    {
        public async Task<string> GetUserDb()
        {
            Console.WriteLine("AuthService hit again");
            var connString = "Host=localhost;Port=5432;Username=bryankrauss;Password=password123;Database=fantasy_stock_users";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            // Retrieve all rows
            await using var cmd = new NpgsqlCommand("SELECT * FROM users;", conn);
            await using var reader = await cmd.ExecuteReaderAsync();

            while (reader.Read())
            {
                //Console.WriteLine(reader.GetString(reader.GetOrdinal("username")));
                var username = reader.GetString(reader.GetOrdinal("password"));
                Console.WriteLine(username);
                return username;
            }
            
            return "Bad news bears.";
        }
    }
}
