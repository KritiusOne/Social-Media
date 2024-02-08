using SocialMedia.Core.Enumeraciones;

namespace SocialMedia.Core.Entities
{
    public class Security : BaseEntity
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

    }
}
