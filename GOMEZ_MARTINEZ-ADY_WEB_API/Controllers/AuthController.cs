using Domain.DTO;
using GOMEZ_MARTINEZ_ADY_WEB_API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace GOMEZ_MARTINEZ_ADY_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthServices _authService;

        public AuthController(IAuthServices authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _authService.Login(request);
            return Ok(new { token });
        }
    }
}