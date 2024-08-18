using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Services;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public AuthController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }

        [HttpPost("token")]
        public IActionResult Token([FromForm] string username, [FromForm] string password, [FromForm] string scope)
        {
            // Normally for OAuth an external endpoint is probably called.
            // But for this demo just call a hidden in-app controller.
            var token = tokenService.GenerateToken(username, password, scope);
            if (token == null)
                return BadRequest("Invalid username or password.");

            return Ok(new { access_token = token });
        }
    }
}
