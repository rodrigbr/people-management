using People.Management.Application.Commands.Validations;
using People.Management.Domain.Core.Models;
using People.Management.Domain.Entites;
using People.Management.Domain.Statics;
using People.Management.Framework.DTOs.Schooling;
using People.Management.Framework.DTOs.SchoolRecord;
using People.Management.Framework.DTOs.User;

namespace People.Management.Application.Commands
{
    public class UpdateSchoolRecordCommand : UserSchoolRecordCommand
    {
        public UpdateSchoolRecordCommand(SchoolRecordWriteDTO dto)
        {
            Id = dto.Id;
            UserId = dto.UserId;
            Name = dto.Name;
            Format = dto.Format;
        }

        public Guid Id { get; private set; }

    }
}
