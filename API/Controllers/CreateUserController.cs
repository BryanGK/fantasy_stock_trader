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

    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginModel userData)
         {
            try
            {
                var newUser = await _userService.CreateUser(userData.Username, userData.Password);

                return Ok(newUser);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
