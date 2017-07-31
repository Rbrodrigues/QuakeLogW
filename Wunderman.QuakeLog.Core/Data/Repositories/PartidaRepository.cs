using Wunderman.QuakeLog.Core.Data.EfContext;
using Wunderman.QuakeLog.Core.Domain.Entities;
using Wunderman.QuakeLog.Core.Domain.Repositories;

namespace Wunderman.QuakeLog.Core.Data.Repositories
{
    public class PartidaRepository : Repository<Partida>, IPartidaRepository
    {
        public PartidaRepository(EfDbContext efContext)
            : base(efContext)
        { }        
    }
}
