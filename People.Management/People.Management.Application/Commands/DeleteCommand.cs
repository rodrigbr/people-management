using People.Management.Application.Commands.Validations;
using People.Management.Domain.Core.Models;

namespace People.Management.Application.Commands
{
    public class DeleteCommand : Command 
    {
        public Guid Id { get; protected set; } 

        public override bool IsValid()
        {
            ValidationResult = new DeleteCommandValidation().Validate(this); 
            return ValidationResult.IsValid;
        }
    }
}
