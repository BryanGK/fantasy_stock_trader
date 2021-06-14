using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [Route("api/[controller]")]

    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public ActionResult<UserSession> Post([FromBody] UserModel userData)
        {

            return Ok(_loginService.CreateSessionByUsername(userData.Username, userData.Password));

        }
    }
}
