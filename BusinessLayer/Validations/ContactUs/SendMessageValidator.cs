using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations.ContactUs
{
    public class SendMessageValidator : AbstractValidator<SendMessageDto>
    {
        public SendMessageValidator()
        {
            RuleFor(X => X.Email).NotEmpty();
            RuleFor(X => X.Subject).NotEmpty();
            RuleFor(X => X.Name).NotEmpty();
            RuleFor(X => X.MessageBody).NotEmpty();

            RuleFor(x => x.Subject).MinimumLength(5);
            RuleFor(x => x.MessageBody).MinimumLength(5);

            RuleFor(x => x.MessageBody).MaximumLength(100);
            RuleFor(x=>x.Subject).MaximumLength(50);
        }
    }
}
