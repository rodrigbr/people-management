using FluentValidation;

namespace People.Management.Application.Commands.Validations
{
    public class DeleteCommandValidation : AbstractValidator<DeleteCommand> 
    {
        public DeleteCommandValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("É obrigatório ter um Id!"); 
        }
    }
}
