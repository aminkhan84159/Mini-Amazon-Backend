using Amazon.Api.Core.Interfaces;
using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class CartValidator : AbstractValidator<Cart>, IAbstrcatValidator
    {
        public CartValidator()
        {
            RuleFor(a => a.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
