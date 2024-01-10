using BloodDonorSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BloodDonorSystem.Controllers;

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetSecureData()
        {
            return Ok("This is secure data!");
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredentials userCredentials)
        {
            if (userCredentials.Name == "admin" && userCredentials.Password == "password")
            {
                var tokenService = new JwtTokenService("DfAO1sxDwgy2SuDTtjYMYEOyR+n0kZJ6niCgdUVVCqM=");
                var token = tokenService.GenerateToken(userCredentials.Name);
                return Ok(token);
            }

            return Unauthorized();
        }

    }


