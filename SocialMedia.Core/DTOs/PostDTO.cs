﻿using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.DTOs
{
    public class PostDTO
    {
        public int PostID { get; set; }
        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public string? Image { get; set; }
    }
}