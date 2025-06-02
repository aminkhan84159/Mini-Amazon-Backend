using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class UserCartValidator : AbstractValidator<UserCart>
    {
        public UserCartValidator()
        {
            RuleFor(a => a.CartId).GreaterThan(0).WithMessage("Cart id can not be less then 0");
            RuleFor(a => a.ProductId).GreaterThan(0).WithMessage("product id can not be less then 0");
        }
    }
}
