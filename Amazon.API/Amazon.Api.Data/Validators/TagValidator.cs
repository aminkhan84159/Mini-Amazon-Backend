using Amazon.Api.Data.Entities;
using FluentValidation;

namespace Amazon.Api.Data.Validators
{
    public class TagValidator : AbstractValidator<Tag>
    {
        public TagValidator()
        {
            RuleFor(a => a.Tags).NotEmpty().WithMessage("Tag is required");
        }
    }
}
