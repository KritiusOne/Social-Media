using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Infraestructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository 
    {

        public PostRepository(SocialMediaContext context) : base(context)
        {

            
        }
        public async Task<IEnumerable<Post>> GetPostsByUser(int idUser)
        {
            return await _entities.Where(x => x.UserId == idUser).ToListAsync();
        }
    }
}
