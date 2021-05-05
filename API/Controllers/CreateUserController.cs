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

    public class CreateUserController : Controller
    {
        private readonly ICreateUserService _createUserService;

        private readonly IAuthService _authService;

        public CreateUserController(ICreateUserService createUserService, IAuthService authService)
        {
            _createUserService = createUserService;
            _authService = authService;
        }

        [HttpPost]
        public ActionResult<UserSession> Post([FromBody] CreateUserModel userData)
         {
            try
            {
                var newUserId = _createUserService.User(userData.Username, userData.Password);
               
                var user = _authService.GetUserById(newUserId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
