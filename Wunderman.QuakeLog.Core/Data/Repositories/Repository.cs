using System.Collections.Generic;
using System.Linq;
using Wunderman.QuakeLog.Core.Data.EfContext;
using Wunderman.QuakeLog.Core.Domain.Repositories;

namespace Wunderman.QuakeLog.Core.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EfDbContext efContext;

        public Repository(EfDbContext efContext)
        {
            this.efContext = efContext;
        }

        public void Add(IList<TEntity> entities)
        {
            efContext.Set<TEntity>().AddRange(entities);
            efContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {           
            return efContext.Set<TEntity>().ToList();
        }
    }
}
