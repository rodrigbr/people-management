using Microsoft.EntityFrameworkCore;
using People.Management.Domain.Contracts;
using People.Management.Infra.Context;

namespace People.Management.Infra.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly MicroServiceContext _context;

        public RepositoryBase(MicroServiceContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
            _context.SaveChanges();
        }

        public virtual TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remove(TEntity obj)
        {
            _context.Set<TEntity>().Remove(obj);
            _context.SaveChanges();
        }

        public void RemoveAll(TEntity[] objs)
        {
            _context.Set<TEntity>().RemoveRange(objs);
            _context.SaveChanges();
        }

        public void Dispose()
        {

        }
    }
}
