﻿using System;
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

    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public ActionResult<UserSession> Post([FromBody] LoginInputModel userData)
         {
            try
            {
                Console.WriteLine($"THIS IS USERDATA: {userData.Username} {userData.Password}");
                return Ok(_authService.GetUserByName(userData.Username, userData.Password));
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
