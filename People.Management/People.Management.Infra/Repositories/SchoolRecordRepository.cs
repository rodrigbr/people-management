using People.Management.Domain.Contracts;
using People.Management.Domain.Entites;
using People.Management.Infra.Context;

namespace People.Management.Infra.Repositories
{
    public class SchoolRecordRepository : RepositoryBase<SchoolRecord>, ISchoolRecordRepository
    {
        public SchoolRecordRepository(MicroServiceContext context) : base(context) 
        {
        }
    }
}
