using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(a => a.ProductId).GreaterThan(0).WithMessage("Product Id can not be less than 0");
        }
    }
}
