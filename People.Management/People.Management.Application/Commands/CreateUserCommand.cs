using People.Management.Application.Commands.Validations;
using People.Management.Framework.DTOs.User;

namespace People.Management.Application.Commands
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand(UserWriteDTO dto)
        {
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            BirthDate = dto.BirthDate;
            Adress = dto.Adress;
            City = dto.City;
            Country = dto.Country;
            Number = dto.Number;
            Uf = dto.Uf;
            ZipCode = dto.ZipCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
