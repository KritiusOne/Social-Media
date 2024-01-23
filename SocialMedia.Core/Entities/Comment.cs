using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities;

public class Comment
{
    public int CommentId { get; set; }

    public int PostId { get; set; }

    public int UserId { get; set; }

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public bool Active { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
