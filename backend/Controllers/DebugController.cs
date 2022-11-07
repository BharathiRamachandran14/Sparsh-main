using Microsoft.AspNetCore.Mvc;
using Sparsh.Models.Request;
using Sparsh.Services;

namespace Sparsh.Controllers {
  [ApiController]
  [Route("/debug")]
  public class DebugController : ControllerBase {
    private readonly IUserService _users;

    public DebugController(
      IUserService users
    ) {
      _users = users;
    }

    [HttpPost]
    public IActionResult DebugCreateAdmin([FromBody] CreateUserRequest userRequest) {
      if (!ModelState.IsValid) {
        return BadRequest(ModelState);
      }

      var newUser = _users.Create(userRequest);

      return Created("/api", newUser);
    }
  }
}
