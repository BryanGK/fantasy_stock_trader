using System;
using System.Text.Json;

namespace API.Models
{
    public class UserLoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
