using SocialMedia.Core.Entities;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepo { get;}
        IRepository<User> UserRepo { get;}
        IRepository<Comment> ComentRepo { get; }
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
