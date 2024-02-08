using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.response;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Enumeraciones;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.API.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        private readonly IMapper _mapper;
        public SecurityController(ISecurityService securityService, IMapper mapper)
        {
            _securityService = securityService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(SecurityDTO security)
        {
            var newSecurity = _mapper.Map<Security>(security);
            await _securityService.RegisterUser(newSecurity);
            var fromResponse = _mapper.Map<SecurityDTO>(newSecurity);
            var response = new ApiResponse<SecurityDTO>(fromResponse);
            return Ok(response);
        }
    }
}
