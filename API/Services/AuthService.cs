using System;
using System.Threading.Tasks;
using API.Models;
using Npgsql;

namespace API.Services
{
    public interface IAuthService
    {
        Task<UserModel> GetUserDb();
    }

    public class AuthService : IAuthService
    {
        public async Task<UserModel> GetUserDb()
        {
            var connString = "Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            // Insert some data
            await using (var cmd = new NpgsqlCommand("INSERT INTO data (some_field) VALUES (@p)", conn))
            {
                cmd.Parameters.AddWithValue("p", "Hello world");
                await cmd.ExecuteNonQueryAsync();
            }

            // Retrieve all rows
            await using (var cmd = new NpgsqlCommand("SELECT some_field FROM data", conn))
            await using (var reader = await cmd.ExecuteReaderAsync())
                while (await reader.ReadAsync())
                    Console.WriteLine(reader.GetString(0));
        }
    }
}
