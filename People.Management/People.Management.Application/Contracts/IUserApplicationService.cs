using FluentValidation.Results;
using People.Management.Framework.DTOs.Schooling;
using People.Management.Framework.DTOs.SchoolRecord;
using People.Management.Framework.DTOs.User;

namespace People.Management.Application.Contracts
{
    public interface IUserApplicationService
    {
        Task<ValidationResult> Create(UserWriteDTO dto);     
        Task<ValidationResult> Update(UserWriteDTO dto);
        Task<ValidationResult> Delete(Guid id); 
        Task<List<UserReadDTO>> GetList(UserQueryDTO dto); 
        Task<UserReadDTO?> GetById(Guid id); 
        Task<ValidationResult> AddSchooling(SchoolingWriteDTO dto); 
        Task<ValidationResult> RemoveSchooling(Guid id); 
        Task<ValidationResult> AddSchoolRecord(SchoolRecordWriteDTO dto); 
        Task<ValidationResult> RemoveSchoolRecord(Guid id); 
    }
}
