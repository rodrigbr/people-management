using People.Management.Application.Commands.Validations;
using People.Management.Domain.Core.Models;
using People.Management.Framework.DTOs.User;

namespace People.Management.Application.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public UpdateUserCommand(UserWriteDTO dto)
        {
            Id = dto.Id;
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

        public Guid Id { get; private set; }

        public override bool IsValid()
        {
            ValidationResult = new UpdateUserCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
