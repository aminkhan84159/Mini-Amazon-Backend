using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(a => a.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(a => a.Category).NotEmpty().WithMessage("Category is missing");
            RuleFor(a => a.Price).GreaterThan(0).WithMessage("Price can not ne less then 0");
            RuleFor(a => a.Rating).GreaterThanOrEqualTo(0).WithMessage("Rating can't be in negative");
        }
    }
}
