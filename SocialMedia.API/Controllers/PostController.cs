using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.Entities;
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
        public async Task<IActionResult> GetPosts()
        {
            var post = await _postRepository.GetPosts();
            return Ok(post);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
           await _postRepository.CreatePost(post);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            await _postRepository.PutPost(id, post);
            return Ok("The elemente is Update");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            int response = await _postRepository.DeletePost(id);
            return response == -1 ? NotFound(id) : Ok("This Element is remove");
        }
    }
}
