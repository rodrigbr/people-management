using FluentValidation.Results;
using MediatR;
using People.Management.Application.Commands;
using People.Management.Application.Contracts;
using People.Management.Domain.Contracts;
using People.Management.Framework.DTOs.Schooling;
using People.Management.Framework.DTOs.SchoolRecord;
using People.Management.Framework.DTOs.User;

namespace People.Management.Application.Implementations
{
    public class UserApplicationService: IUserApplicationService
    {
        private readonly IMediator _mediator;
        private readonly IUserDapperRepository _userDapperRespository;

        public UserApplicationService(
            IMediator mediator,
            IUserDapperRepository userDapperRespository)
        {
            _mediator = mediator;
            _userDapperRespository = userDapperRespository;
        }

        public async Task<ValidationResult> Create(UserWriteDTO dto)
        {
            return await _mediator.Send(new CreateUserCommand(dto));
        }

        public async Task<ValidationResult> Update(UserWriteDTO dto)
        {
            return await _mediator.Send(new UpdateUserCommand(dto));
        }

        public async Task<ValidationResult> Delete(Guid id)
        {
            return await _mediator.Send(new DeleteUserCommand(id));
        }

        public async Task<List<UserReadDTO>> GetList(UserQueryDTO dto)
        {
            var result = await _userDapperRespository.GetList(dto.PageIndex, dto.PageSize);
            return result.ToList();
        }

        public async Task<UserReadDTO?> GetById(Guid id)
        {
            var result = await _userDapperRespository.GetById(id);
            return result.FirstOrDefault();
        }

        public async Task<ValidationResult> AddSchooling(SchoolingWriteDTO dto)
        {
            return await _mediator.Send(new UpdateSchoolingCommand(dto));
        }

        public async Task<ValidationResult> AddSchoolRecord(SchoolRecordWriteDTO dto)
        {
            return await _mediator.Send(new UpdateSchoolRecordCommand(dto));
        }
        public async Task<ValidationResult> RemoveSchoolRecord(Guid id)
        {
            return await _mediator.Send(new DeleteSchoolRecordCommand(id));
        }
        public async Task<ValidationResult> RemoveSchooling(Guid id)
        {
            return await _mediator.Send(new DeleteSchoolingCommand(id));
        }
    }
}
