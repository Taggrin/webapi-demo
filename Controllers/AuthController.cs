using Microsoft.AspNetCore.Mvc;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Token([FromForm] string username, [FromForm] string password, [FromForm] string scope)
        {
            return Ok();
        }
    }
}
