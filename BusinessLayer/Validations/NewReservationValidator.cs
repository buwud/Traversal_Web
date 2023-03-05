using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class NewReservationValidator : AbstractValidator<Reservation>
    {
        public NewReservationValidator()
        {
            //RuleFor(x => x.Destination).NotEmpty().WithMessage("Select a city");
            RuleFor(x => x.PersonNum).NotEmpty().WithMessage("Enter a number");
            RuleFor(x => x.ReservationTime).NotEmpty().WithMessage("Select a date");
            RuleFor(x => x.Description).MaximumLength(200);
            //RuleFor(x=>x.ReservationTime).
        }
    }
}