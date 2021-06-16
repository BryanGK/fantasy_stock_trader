using System;
using System.Collections.Generic;
using API.Models;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public CreateUserController(ICreateUserService createUserService,
            ILoginService loginService,
            IMapper mapper)
        {
            _createUserService = createUserService;
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<UserSessionModel> Post([FromBody] UserInputModel userData)
        {

            var newUser = _createUserService.CreateUser(userData.Username, userData.Password);
            var newUserId = newUser.UserId.ToString();
            var walletUserId = _createUserService.CreateWallet(newUserId);

            if (walletUserId != newUserId)
                return StatusCode(500, "Server Error");

            var userSession = _loginService.CreateSessionByUserId(newUserId);

            var mappedUserSession = _mapper.Map<UserSessionModel>(userSession);

            return Ok(mappedUserSession);

        }
    }
}
