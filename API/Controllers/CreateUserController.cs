using System;
using Core.Entities;
using Core.Models;
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
            var newUser = _createUserService.CreateUser(userData.Username, userData.Password);
            var newUserId = newUser.UserId.ToString();
            var walletUserId = _createUserService.CreateWallet(newUserId);

            if (walletUserId != newUserId)
                return StatusCode(500, "Server Error");

            return Ok(_loginService.CreateSessionByUserId(newUserId));

        }
    }
}
