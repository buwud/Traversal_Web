using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This field cannot be empty.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("This field cannot be empty.");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("This field cannot be empty.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("This field cannot be empty.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("This field cannot be empty.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("This field cannot be empty.");
            //more can be added 
            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords do not match!");
        }
    }
}