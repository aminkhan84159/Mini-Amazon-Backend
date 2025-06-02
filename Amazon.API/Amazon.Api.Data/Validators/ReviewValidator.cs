using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class ReviewValidator : AbstractValidator<Review>
    {
        public ReviewValidator()
        {
            RuleFor(a => a.ProductId).GreaterThan(0).WithMessage("Product Id can not be less then 0");
            RuleFor(a => a.ReviewerName).NotEmpty().WithMessage("Name is missing");
            RuleFor(a => a.ReviewerEmail).NotEmpty().WithMessage("Email is missing").EmailAddress().WithMessage("Invalid email");
            RuleFor(a => a.Rating).GreaterThanOrEqualTo(0).WithMessage("Rating can't be in negative");
        }
    }
}
