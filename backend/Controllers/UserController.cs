using Microsoft.AspNetCore.Mvc;
using System;
using Sparsh.Services;
using Sparsh.Helpers;
using Sparsh.Models.Request;
using Sparsh.Models.Database;
using Sparsh.Models.Response;
using Sparsh.Exceptions;

namespace Sparsh.Controllers
{
    [ApiController]
    [Route("/users")]
    public class UserController : ControllerBase
    {

        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public UserController
        (
            IAuthService authService,
            IUserService userService
        )
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("create")]
        public ActionResult<UserResponse> Create([FromHeader] string authorization, [FromBody] CreateUserRequest newUserRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (authorization is null)
            {
                return new UnauthorizedResult();
            }


            (string username, string password) = AuthHelper.GetUsernameAndPassword(authorization);

            var check = _authService.IsValidLoginInfo(username, password);

            if (!check)
            {
                return new UnauthorizedResult();
            }

            try
            {
                User createdUser = _userService.Create(newUserRequest);
                return new UserResponse(createdUser);
            }
            catch (DuplicateUsernameException)
            {
                return BadRequest("Username already exists");
            }
        }
    }
}
