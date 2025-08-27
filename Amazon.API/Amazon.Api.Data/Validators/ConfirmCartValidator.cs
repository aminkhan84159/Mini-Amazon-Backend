using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class ConfirmCartValidator : AbstractValidator<ConfirmCart>
    {
        public ConfirmCartValidator()
        {
            RuleFor(x => x.CartId).GreaterThan(0).WithMessage("CartId must be greater than 0");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("UserId must be greater than 0");
        }
    }
}
