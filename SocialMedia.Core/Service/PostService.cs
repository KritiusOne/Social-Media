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
        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        public PostService(IRepository<Post> postRepository, IRepository<User> userR)
        {
            _postRepository = postRepository;
            _userRepository = userR;
        }
        public async Task<Post> GetPost(int id)
        {
            var response = await _postRepository.GetById(id);
            return response;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var response = await _postRepository.GetAll();
            return response;
        }
        public async Task<int> CreatePost(Post post)
        {
            var user = await _userRepository.GetById(post.UserId);
            Console.WriteLine(user);
            if (user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (post.Description.Contains("sex"))
            {
                throw new Exception("El post rompe las reglas de la comunidad");
            }
            await _postRepository.Add(post);
            return post.Id;
        }
        public async Task<int> PutPost(int id, Post post)
        {
            await _postRepository.Update(id, post);
            return post.Id;
        }
        public async Task<int> DeletePost(int id)
        {
            await _postRepository.Delete(id);
            return id;
        }
    }
}
