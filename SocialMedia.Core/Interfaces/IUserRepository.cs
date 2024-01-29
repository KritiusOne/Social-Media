using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;

namespace SocialMedia.Infraestructure.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task<int> CreateUser(User post);
        Task<int> PutUser(UserDTO post);
        Task<int> DeleteUser(int id);
    }
}