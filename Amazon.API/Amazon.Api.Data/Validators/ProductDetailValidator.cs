using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class ProductDetailValidator : AbstractValidator<ProductDetail>
    {
        public ProductDetailValidator()
        {
            RuleFor(a => a.ProductId).GreaterThan(0).WithMessage("ProductId can not be less then 0");
            RuleFor(a => a.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(a => a.Stock).GreaterThanOrEqualTo(0).WithMessage("Stock can't be in negative");
            RuleFor(a => a.Sku).NotEmpty().WithMessage("sku is required");
            RuleFor(a => a.Weight).GreaterThan(0).WithMessage("weight can't be negative");
            RuleFor(a => a.Discount).GreaterThan(0).WithMessage("Discount can't be negative");
            RuleFor(a => a.Warranty).NotEmpty().WithMessage("warranty is required");
            RuleFor(a => a.ReturnPolicy).NotEmpty().WithMessage("Return policy is required");
        }
    }
}
