using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("first name is required");
            RuleFor(a => a.LastName).NotEmpty().WithMessage("last name is required");
            RuleFor(a => a.Email).NotEmpty().EmailAddress().WithMessage("Invlaid email");
            RuleFor(a => a.Username).NotEmpty().WithMessage("username is required");
            RuleFor(a => a.Password).Length(8, 32).WithMessage("minimum 8 and maximum 32 characters are allowed").NotEmpty().WithMessage("Password is required");
            RuleFor(a => a.PhoneNo).Matches(@"^\d{10}$").WithMessage("PhoneNo must be a 10-digit number.");
        }
    }
}
