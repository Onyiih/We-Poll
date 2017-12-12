using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WePoll.Domain.Models
{
    public abstract class Model : IValidatableObject
    {
        public void Validate()
        {
            Validator.ValidateObject(this, new ValidationContext(this));
        }
        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return new ValidationResult[] { };
        }
    }
}