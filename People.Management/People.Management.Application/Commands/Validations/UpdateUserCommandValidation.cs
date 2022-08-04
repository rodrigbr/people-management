using FluentValidation;

namespace People.Management.Application.Commands.Validations
{
    public class UpdateUserCommandValidation : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidation() 
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("É obrigatório ter um usuário!");
        }
    }
}
