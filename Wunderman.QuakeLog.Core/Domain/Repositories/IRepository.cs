using System.Collections.Generic;

namespace Wunderman.QuakeLog.Core.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {    
        void Add(IList<TEntity> entities);
        IEnumerable<TEntity> GetAll();     
    }
}
