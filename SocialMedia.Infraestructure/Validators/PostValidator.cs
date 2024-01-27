using FluentValidation;
using SocialMedia.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infraestructure.Validators
{
    public class PostValidator : AbstractValidator<PostDTO>
    {
        public PostValidator()
        {
            RuleFor(p => p.Description).NotNull().Length(10, 1000);
            RuleFor(p => p.Date).NotNull().NotEmpty();

        }

    }
}
