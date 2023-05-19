using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations.Announcement
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddValidatorDTO>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.Title).MinimumLength(3);
            RuleFor(x => x.Content).MinimumLength(25);
            RuleFor(x => x.Title).MaximumLength(50);
            RuleFor(x => x.Content).MaximumLength(500);
        }
    }
}