using Microsoft.AspNetCore.Mvc;
using SocialMedia.Core.DTOs;
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
            var postsDTO = post.Select(p => new PostDTO
            {
                PostID = p.PostId,
                UserId = p.UserId,
                Date = p.Date,
                Description = p.Description,
                Image = p.Image
            });
            return Ok(postsDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            return Ok(post);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO post)
        {
           await _postRepository.CreatePost(post);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutPost(PostDTO post)
        {
            await _postRepository.PutPost(post);
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
