using Microsoft.AspNetCore.Mvc;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;

namespace PaintServer.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserAutorizationData userAutorizationData)
        {
            var person = _authService.Login(userAutorizationData);

            return Ok(person.Id);
        }

        [HttpPost]
        public IActionResult Signup([FromBody] UserRegistrationData userRegistrationData)
        {
            var person = _authService.Signup(userRegistrationData);

            return Ok(person.Id);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePasswordDTO userAutorizationData)
        {
            var result = _authService.UpdatePassword(userAutorizationData);

            return Ok(result);
        }
    }
}
