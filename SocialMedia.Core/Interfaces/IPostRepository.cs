using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPosts();
        Task<Post> GetPost(int id);
        Task CreatePost(Post post);
        Task PutPost(int id, Post post);
        Task<int> DeletePost(int id);
    }
}
