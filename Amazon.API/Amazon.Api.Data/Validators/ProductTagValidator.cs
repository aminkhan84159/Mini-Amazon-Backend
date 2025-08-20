using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class ProductTagValidator : AbstractValidator<ProductTag>
    {
        public ProductTagValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("ProductId is required.");
            RuleFor(x => x.TagId).NotEmpty().WithMessage("TagId is required.");
        }
    }
}
