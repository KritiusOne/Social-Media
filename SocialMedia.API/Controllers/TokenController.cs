using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _config;
        public TokenController(IConfiguration configuration)
        {
            _config = configuration;
        }
        [HttpPost]
        public IActionResult Authentication(UserLogin user)
        {
            if (isValidUser(user))
            {
                var token = GenerateToken();
                return Ok(new { token });
            }
            return NotFound();
        }
        private bool isValidUser(UserLogin user)
        {
            return true;
        }
        private string GenerateToken()
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SecretKey"]));
            var SingInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(SingInCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Julio Rodriguez"),
                new Claim(ClaimTypes.Email, "julio10489@gmail.com"),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            //payloads
            var payload = new JwtPayload
            (
             _config["Authentication:Issuer"], 
             _config["Authentication:Audience"], 
             claims, 
             DateTime.Now, 
             DateTime.UtcNow.AddMinutes(2)
             );
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
