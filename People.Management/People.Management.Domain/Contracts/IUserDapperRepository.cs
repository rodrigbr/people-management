using People.Management.Domain.Entites;
using People.Management.Framework.DTOs.User;

namespace People.Management.Domain.Contracts
{
    public interface IUserDapperRepository 
    {
        Task<IEnumerable<UserReadDTO>> GetList(int pageIndex, int pageSize);
        Task<IEnumerable<UserReadDTO?>> GetById(Guid id);
    }
}
