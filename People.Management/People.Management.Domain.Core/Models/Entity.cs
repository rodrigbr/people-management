using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace People.Management.Domain.Core.Models
{
    public class Entity
    {
        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            ValidationResult = new ValidationResult();
        }

        public void AddValidationError(string error, string description)
        {
            ValidationResult.Errors.Add(new ValidationFailure(error, description));
        }

        public virtual bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
