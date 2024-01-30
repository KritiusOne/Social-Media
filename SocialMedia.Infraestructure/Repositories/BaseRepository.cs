using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Data;

namespace SocialMedia.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly SocialMediaContext _socialMediaContext;
        private readonly DbSet<T> _entities;
        public BaseRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
            _entities = socialMediaContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _socialMediaContext.SaveChangesAsync();
        }
        public async Task Update(int id,T entity)
        {
            _entities.Update(entity);
            await _socialMediaContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var response = await GetById(id);
            _socialMediaContext.Remove(response);
            await _socialMediaContext.SaveChangesAsync();
        }
    }
}
