using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class CreateUserController : Controller
    {
        private readonly ICreateUserService _createUserService;

        private readonly ILoginService _loginService;

        public CreateUserController(ICreateUserService createUserService, ILoginService loginService)
        {
            _createUserService = createUserService;
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult<UserSession> Post([FromBody] UserModel userData)
         {
            try
            {
                var newUserId = _createUserService.Create(userData.Username, userData.Password);

                _createUserService.Wallet(newUserId.UserId.ToString());

                var user = _loginService.GetUserById(newUserId.UserId.ToString());

                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
