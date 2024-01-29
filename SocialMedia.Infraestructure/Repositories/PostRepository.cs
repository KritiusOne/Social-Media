using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Infraestructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _context;
        public PostRepository(SocialMediaContext context)
        {
            _context = context;
            
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _context.Posts.ToListAsync();
            return posts;
        }
        public async Task<Post> GetPost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                throw new Exception($"No se encuentran registros en la tabla post para {id}");
            }
            return post;
        }
        public async Task<int> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return post.UserId;            
        }
        public async Task<int> PutPost(PostDTO post)
        {
            var updatedPost = await _context.Posts.FindAsync(post.PostId);
            if(updatedPost == null)
            {
                return -1;
            }
            updatedPost.Description = post.Description;
            updatedPost.Image = post.Image;
            updatedPost.Date = post.Date; //Quiza en la inteligencia del negocio sea mejor que haya un campo que sea updateDate y CreatedDate: 
            _context.Posts.Update(updatedPost);
            await _context.SaveChangesAsync();
            return post.PostId;
        }
        public async Task<int> DeletePost(int id)
        {
            var response = await _context.Posts.FindAsync(id);
            if (response == null){
                return -1;
            }
            _context.Posts.Remove(response);
            await _context.SaveChangesAsync();
            return id;
        }
        
    }
}
