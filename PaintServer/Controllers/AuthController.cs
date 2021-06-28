using DAL.Models;
using DTO;
using Microsoft.AspNetCore.Mvc;
using PaintServer.Interfaces;
using PaintServer.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaintServer.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] UserAutorizationData userAutorizationData)
        {
            var person = _authService.Login(userAutorizationData);

            return Ok(person);
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdatePasswordDTO userAutorizationData)
        {
            var result = _authService.UpdatePassword(userAutorizationData);

            return Ok(result);
        }
    }
}
