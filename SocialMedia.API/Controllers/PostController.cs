using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Interfaces;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //Inyección de dependencias 
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;            
        }
        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            var post = await _postRepository.GetPosts();
            return Ok(post);
        }
    }
}
