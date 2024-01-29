using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SocialMediaContext _context;
        public UserRepository(SocialMediaContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserId == id);
            return user;
        }

        public Task<int> CreateUser(User post)
        {
            throw new NotImplementedException();
        }

        public Task<int> PutUser(UserDTO post)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
