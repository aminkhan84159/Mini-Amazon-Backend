﻿using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazon.Api.Core.Data
{
    public abstract class ObjectBase
    {
        private readonly IValidator _validator = null!;
        private IEnumerable<ValidationFailure> _validationErrors = null!;
        protected ObjectBase()
        {
            _validator = GetValidator();
            Validate();
        }

        protected virtual IValidator GetValidator()
        {
            throw new NotImplementedException();
        }

        [NotMapped]
        public IEnumerable<ValidationFailure> ValidationErrors
        {
            get { return _validationErrors; }
        }

        public void Validate()
        {
            if (_validator is not null)
            {
                var context = new ValidationContext<object>(this);
                ValidationResult result = _validator.Validate(context);
                _validationErrors = result.Errors;
            }
        }

        [NotMapped]
        public virtual bool IsValid
        {
            get
            {
                if (_validationErrors is not null && _validationErrors.Any())
                    return false;
                else
                    return true;
            }
        }

        public List<string> GetValidationErrors()
        {
            List<string> validationErrors = [];

            foreach (var validationError in _validationErrors!)
            {
                validationErrors.Add(validationError.ErrorMessage);
            }

            return validationErrors;
        }
    }
}
