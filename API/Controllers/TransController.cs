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

    public class TransController : Controller
    {
        private readonly IAuthService _authService;

        public TransController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("buy")]
        [HttpPost]
        public ActionResult<UserSession> Post([FromBody] LoginModel userData)
         {
            try
            {
                return Ok(_authService.GetUserByName(userData.Username, userData.Password));
            }
            catch (Exception e)
            {
                return StatusCode(500, $"{e.Message} {e.StackTrace} - Something's not right.");
            }
        }
    }
}
