using SocialMedia.Core.Entities;
using SocialMedia.Core.QueryFilter;

namespace SocialMedia.Core.Interfaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts(PostQueryFilter filter);
        Task<Post> GetPost(int id);
        Task<int> CreatePost(Post post);
        Task<int> PutPost(int id, Post post);
        Task<int> DeletePost(int id);
    }
}