using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infraestructure.Repositories;
//Reglas que se implementarán:
//1. Si se desea publicar un post debe ser un usuario previamente registrado 
//2. Si el user tiene menos de 10 post, solo puede hacer 1 por semana
//3. No se permite publicar info referente al sexo
namespace SocialMedia.Core.Interfaces
{

    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Post> GetPost(int id)
        {
            var response = await _unitOfWork.PostRepo.GetById(id);
            return response;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var response = await _unitOfWork.PostRepo.GetAll();
            return response;
        }
        public async Task<int> CreatePost(Post post)
        {
            var user = await _unitOfWork.UserRepo.GetById(post.UserId);
            Console.WriteLine(user);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (post.Description.Contains("sex"))
            {
                throw new Exception("El post rompe las reglas de la comunidad");
            }
            await _unitOfWork.PostRepo.Add(post);
            return post.Id;
        }
        public async Task<int> PutPost(int id, Post post)
        {
            await _unitOfWork.PostRepo.Update(id, post);
            return post.Id;
        }
        public async Task<int> DeletePost(int id)
        {
            await _unitOfWork.PostRepo.Delete(id);
            return id;
        }
    }
}
