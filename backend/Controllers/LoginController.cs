using Microsoft.AspNetCore.Mvc;
using System;
using Sparsh.Services;
using Sparsh.Helpers;

namespace Sparsh.Controllers {
    [ApiController]
    [Route("/login")]
    public class LoginController : ControllerBase {

        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public LoginController
        (
            IAuthService authService,
            IUserService userService
        ) {
            _authService = authService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Login([FromHeader(Name = "Authorization")] string authHeader) {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (authHeader is null)
            {
                return new UnauthorizedResult();
            }

            try
            {
                (string username, string password) = AuthHelper.GetUsernameAndPassword(authHeader);

                var check = _authService.IsValidLoginInfo(username, password);
                if (!check)
                {
                    return new UnauthorizedResult();
                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return new UnauthorizedResult();
            }
        }
    }
}
