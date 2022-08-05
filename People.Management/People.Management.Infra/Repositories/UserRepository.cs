using Microsoft.EntityFrameworkCore;
using People.Management.Domain.Contracts;
using People.Management.Domain.Entites;
using People.Management.Infra.Context;

namespace People.Management.Infra.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository 
    {
        public UserRepository(MicroServiceContext context) : base(context) 
        {

        }

        public Task<User?> GetByIdWithSchooling(Guid id)
        {
            return _context.Users
                .Include(x => x.Schooling)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
        public Task<User?> GetByIdWithSchoolRecord(Guid id)
        {
            return _context.Users
                .Include(x => x.SchoolRecord)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<User?> GetByIdWithSchoolRecordAndSchooling(Guid id)
        {
            return _context.Users
                .Include(x => x.SchoolRecord)
                .Include(x => x.Schooling)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
