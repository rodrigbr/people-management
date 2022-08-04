using People.Management.Domain.Contracts;
using People.Management.Domain.Entites;
using People.Management.Infra.Context;

namespace People.Management.Infra.Repositories
{
    public class SchoolingRepository : RepositoryBase<Schooling>, ISchoolingRepository
    {
        public SchoolingRepository(MicroServiceContext context) : base(context) 
        {
        }
    }
}
