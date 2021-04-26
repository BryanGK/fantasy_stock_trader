using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(string username, string password) // Body of Post { username: "Bryan", password: "123" }
         {
            // Get user in database where username is: "Bryan"
            // If user does not exist
            // return 403 forbidden
            // If user password matches "123"
            // return user id to client
            // else
            // return 403 forbidden

            try
            {
                return Ok(await _authService.GetUserDb(username, password));
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
