using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
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
        private readonly ISecurityService _security;
        public TokenController(IConfiguration configuration, ISecurityService security)
        {
            _config = configuration;
            _security = security;
        }
        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin user)
        {
            var validation = await isValidUser(user);
            if (validation.Item1)
            {
                var token = GenerateToken(validation.Item2);
                return Ok(new { token });
            }
            return NotFound();
        }
        private async Task<(bool, Security)> isValidUser(UserLogin Login)
        {
            var user = await _security.GetLoginByCredentials(Login);

            return (user != null, user);
        }
        private string GenerateToken(Security security)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SecretKey"]));
            var SingInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(SingInCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.User),
                new Claim("User", security.UserName),   
                new Claim(ClaimTypes.Role, security.Role.ToString()),
            };

            //payloads
            var payload = new JwtPayload
            (
             _config["Authentication:Issuer"], 
             _config["Authentication:Audience"], 
             claims, 
             DateTime.Now, 
             DateTime.UtcNow.AddMinutes(10)
             );
            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
