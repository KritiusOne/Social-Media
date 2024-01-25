using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<PostDTO> GetPost(int id);
        Task CreatePost(PostDTO post);
        Task<int> PutPost(PostDTO post);
        Task<int> DeletePost(int id);
    }
}
