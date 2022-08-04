using People.Management.Application.Commands.Validations;
using People.Management.Domain.Core.Models;
using People.Management.Domain.Entites;
using People.Management.Domain.Statics;
using People.Management.Framework.DTOs.Schooling;
using People.Management.Framework.DTOs.User;

namespace People.Management.Application.Commands
{
    public class UpdateSchoolingCommand : UserSchoolingCommand
    {
        public UpdateSchoolingCommand(SchoolingWriteDTO dto)
        {
            Id = Id;
            UserId = dto.UserId;
            SchoolingId = dto.SchoolingTypeId;
        }

        public Guid Id { get; private set; }

    }
}
