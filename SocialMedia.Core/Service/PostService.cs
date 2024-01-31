using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Exceptions;
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

        public IEnumerable<Post> GetPosts()
        {
            var response =  _unitOfWork.PostRepo.GetAll();
            return response;
        }
        public async Task<int> CreatePost(Post post)
        {
            var user = await _unitOfWork.UserRepo.GetById(post.UserId);
            if (user == null)
            {
                throw new BussinessException("User doesn't exist");
            }
            if (post.Description.Contains("sex"))
            {
                throw new BussinessException("El post rompe las reglas de la comunidad");
            }
            var UserPost = await _unitOfWork.PostRepo.GetPostsByUser(post.UserId);
            Console.WriteLine(UserPost.Count());
            if(UserPost.Count() < 10)
            {
                var lastPost = UserPost.OrderByDescending(x => x.Date).FirstOrDefault();
                if((DateTime.Now - lastPost.Date).TotalDays < 7)
                {
                    throw new BussinessException("You are not able from publish");
                }
            }
            await _unitOfWork.PostRepo.Add(post);
            await _unitOfWork.SaveChangesAsync();
            return post.Id;
        }
        public async Task<int> PutPost(int id, Post post)
        {
            _unitOfWork.PostRepo.Update(id, post);
            await _unitOfWork.SaveChangesAsync();
            return post.Id;
        }
        public async Task<int> DeletePost(int id)
        {
            await _unitOfWork.PostRepo.Delete(id);
            return id;
        }
    }
}
