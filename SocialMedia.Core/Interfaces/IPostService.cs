using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);
        Task<int> CreatePost(Post post);
        Task<int> PutPost(PostDTO post);
        Task<int> DeletePost(int id);
    }
}