using People.Management.Domain.Entites;

namespace People.Management.Domain.Contracts
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User?> GetByIdWithSchooling(Guid id);
        Task<User?> GetByIdWithSchoolRecord(Guid id);
    }
}
