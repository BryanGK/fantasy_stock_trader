using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;


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
        public async Task<IActionResult> Post([FromBody]UserLoginModel loginData)
         {
            try
            {
                var validUser = await _authService.DoesUserExist(loginData.Username);

                if (!validUser)
                {
                    return StatusCode(403, "User not found");
                }

                UserModel user = (UserModel)await _authService.GetUserDb(loginData.Username, loginData.Password);

                return Ok(user);

            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
