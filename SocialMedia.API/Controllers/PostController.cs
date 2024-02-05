using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.API.response;
using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilter;
using SocialMedia.Infraestructure.Service;
using System.Net;

namespace SocialMedia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        //Inyección de dependencias 
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        public PostController(IPostService postService, IMapper mapper, IUriService uri)
        {
            _postService = postService;
            _mapper = mapper;
            _uriService = uri;
        }
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPosts( [FromQuery]PostQueryFilter filter)
        {
            var post = _postService.GetPosts(filter);
            var postsDTO = _mapper.Map<IEnumerable<PostDTO>>(post);
            var metadata = new MetaData
            {
                CurrentPage = post.CurrentPage,
                PageSize = post.PageSize,
                TotalCount = post.PageCount,
                HasNextPage = post.hasNextPage,
                HasPreviousPage = post.hasPreviousPage,
                NextPageURL = _uriService.GetPostPaginationUri(filter, Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageURL = _uriService.GetPostPaginationUri(filter, Url.RouteUrl(nameof(GetPosts))).ToString()
            };
            var response = new ApiResponse<IEnumerable<PostDTO>>(postsDTO)
            {
                Message = "this requiest is sucess",
                StatusCode = 200
            };
            response.Meta = metadata;
            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postService.GetPost(id);
            PostDTO postDTO = _mapper.Map<PostDTO>(post);

            var response = new ApiResponse<PostDTO>(postDTO)
            {
                Message = "this requiest is sucess",
                StatusCode = 200
            };
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostDTO post)
        {
            Post newPost = _mapper.Map<Post>(post);
            var response = await _postService.CreatePost(newPost);
            var toResponse = new ApiResponse<int>(response)
            {
                Message = "The New Post is created",
                StatusCode = 201
            };
            return Ok(toResponse); //la validaciones son por medio de los filtros, dejando nuestros controlladores / endpoints mas limpios
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, PostDTO post)
        {
            var UpdatePost = _mapper.Map<Post>(post);
            var response = await _postService.PutPost(id, UpdatePost);
            var toResponse = new ApiResponse<int>(response)
            {
                Message = "The elemente is Update",
                StatusCode = 200
            };
            return Ok(toResponse);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            int response = await _postService.DeletePost(id);
            var toResponse = new ApiResponse<int>(response)
            {
                Message = "The elemente is delete",
                StatusCode = 200
            };
            return Ok(toResponse);
        }
    }
}
