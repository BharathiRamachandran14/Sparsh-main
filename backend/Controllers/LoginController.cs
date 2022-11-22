using Microsoft.AspNetCore.Mvc;
using System;
using Sparsh.Services;
using Sparsh.Helpers;
using Sparsh.Models.Database;
using Sparsh.Models.Response;

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
        public ActionResult<UserResponse> Login([FromHeader(Name = "Authorization")] string authHeader) {

            User user;
            
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
                user =  _authService.GetUserByLogin(username, password);
            }
            catch (ArgumentException)
            {
                return Unauthorized("Username and Password combination not valid!!");
            }

            return new UserResponse(user);
        }
    }
}
