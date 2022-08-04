using FluentValidation;

namespace People.Management.Application.Commands.Validations
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand> 
    {
        public CreateUserCommandValidation() 
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Nome tem que ser preenchido")
                .Length(0, 100).WithMessage("Tamanho do campo nome excedido");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Sobrenome tem que ser preenchido")
                .Length(0, 100).WithMessage("Tamanho do campo sobrenome excedido");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email tem que ser preenchido")
                .EmailAddress().WithMessage("Um E-mail Válido é necessário")
                .Length(0, 100).WithMessage("Tamanho do campo email excedido");

            RuleFor(c => c.BirthDate)
                .NotEmpty().WithMessage("Data de Nascimento tem que ser preenchido.")
                .LessThan(p => DateTime.Now).WithMessage("Data de Nascimento não pode ser maior que hoje.");
        }
    }
}
