namespace SocialMedia.Core.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string? Phone { get; set; }

        public bool isActive { get; set; }
    }
}
