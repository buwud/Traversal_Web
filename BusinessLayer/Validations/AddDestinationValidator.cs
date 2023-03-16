using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class AddDestinationValidator : AbstractValidator<Destination>
    {
        public AddDestinationValidator()
        {
            RuleFor(x => x.City).NotEmpty();
            RuleFor(x => x.City).MinimumLength(3);
            RuleFor(x => x.City).MaximumLength(40);

            RuleFor(x => x.StayTime).NotEmpty();
            RuleFor(x => x.StayTime).MinimumLength(5);
            RuleFor(x => x.StayTime).MaximumLength(40);

            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(100);
            RuleFor(x => x.Price).LessThanOrEqualTo(100000);

            RuleFor(x => x.Capacity).NotEmpty();
            //RuleFor(x => x.Image).NotEmpty().WithMessage("Upload a photo");
            //RuleFor(x => x.Image1).NotEmpty().WithMessage("Upload a photo");
            //RuleFor(x => x.CoverImage).NotEmpty().WithMessage("Upload a photo for covering");
            //RuleFor(x => x.CoverImage).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Details).NotEmpty();
            RuleFor(x => x.Details1).NotEmpty();
        }
    }
}