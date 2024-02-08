using SocialMedia.Core.Enumeraciones;

namespace SocialMedia.Core.DTOs
{
    public class SecurityDTO
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles? Role { get; set; }
    }
}
