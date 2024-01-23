using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string? Phone { get; set; }

    public bool isActive { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
