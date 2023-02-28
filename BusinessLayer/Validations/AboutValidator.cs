using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
	public class AboutValidator:AbstractValidator<About>
	{
		public AboutValidator() 
		{
			RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be empty!");
			RuleFor(x=>x.Description).MinimumLength(20).WithMessage("Description must be at least 20 characters long!");

			RuleFor(x => x.Description2).NotEmpty().WithMessage("Description cannot be empty!");
			RuleFor(x => x.Description2).MinimumLength(20).WithMessage("Description must be at least 20 characters long!");

			RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty!");
			RuleFor(x => x.Title).MinimumLength(3).WithMessage("Title must be at least 3 characters long!");
			RuleFor(x => x.Title).MaximumLength(30).WithMessage("Title should be no more than 30 characters long!");

			
			
		}
	}
}
