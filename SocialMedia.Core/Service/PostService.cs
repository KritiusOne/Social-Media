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
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        public PostService(IPostRepository postRepository, IUserRepository userR)
        {
            _postRepository = postRepository;
            _userRepository = userR;
        }

        public async Task<int> CreatePost(Post post)
        {
            var user = await _userRepository.GetUserAsync(post.UserId);
            Console.WriteLine(user);
            if(user == null)
            {
                throw new Exception("User doesn't exist");
            }
            if (post.Description.Contains("sex"))
            {
                throw new Exception("El post rompe las reglas de la comunidad");
            }
            var response = await _postRepository.CreatePost(post);
            return response;
        }

        public async Task<int> DeletePost(int id)
        {
            var response = await _postRepository.DeletePost(id);
            return response;
        }

        public async Task<Post> GetPost(int id)
        {
            var response = await _postRepository.GetPost(id);
            return response;
        }

        public async Task<IEnumerable<Post>> GetPosts()
        {
            var response = await _postRepository.GetPosts();
            return response;
        }

        public async Task<int> PutPost(PostDTO post)
        {
            var response = await _postRepository.PutPost(post);
            return response;
        }
    }
}
