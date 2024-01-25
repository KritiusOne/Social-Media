using AutoMapper;
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
        private readonly IMapper _mapper;
        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var post = await _postRepository.GetPosts();
            var postsDTO = _mapper.Map<IEnumerable<PostDTO>>(post);
            return Ok(postsDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postRepository.GetPost(id);
            PostDTO postDTO = _mapper.Map<PostDTO>(post);
            return Ok(postDTO);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO post)
        {
            Post newPost = _mapper.Map<Post>(post);
            int response = await _postRepository.CreatePost(newPost);
            return response == 1? Ok(newPost) : NotFound("Error al crear el nuevo post");
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
