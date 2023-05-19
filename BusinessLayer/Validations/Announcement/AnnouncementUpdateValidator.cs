using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;

namespace BusinessLayer.Validations.Announcement
{
    public class AnnouncementUpdateValidator:AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
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