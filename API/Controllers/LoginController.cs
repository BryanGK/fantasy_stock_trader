using API.Models;
using AutoMapper;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]

    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public LoginController(ILoginService loginService, IMapper mapper)
        {
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<UserSessionModel> Post([FromBody] UserInputModel userData)
        {

            var userSession = _loginService.CreateSessionByUsername(userData.Username, userData.Password);

            var mappedUserSession = _mapper.Map<UserSessionModel>(userSession);

            return Ok(mappedUserSession);

        }
    }
}
