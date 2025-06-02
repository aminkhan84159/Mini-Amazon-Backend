using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class ImageTypeValidator : AbstractValidator<ImageType>
    {
        public ImageTypeValidator()
        {
            RuleFor(a => a.Name).NotEmpty()
                .WithMessage("Name is required")
                .MaximumLength(50)
                .WithMessage("Name must be less than 50 characters");
        }
    }
}
