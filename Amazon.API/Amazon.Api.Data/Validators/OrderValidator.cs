using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(a => a.UserId).GreaterThan(0).WithMessage("User Id can not be less then 0");
            RuleFor(a => a.ProductId).GreaterThan(0).WithMessage("Product Id can not be less then 0");
        }
    }
}
