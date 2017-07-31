using Wunderman.QuakeLog.Core.Data.EfContext;
using Wunderman.QuakeLog.Core.Domain.Entities;
using Wunderman.QuakeLog.Core.Domain.Repositories;

namespace Wunderman.QuakeLog.Core.Data.Repositories
{
    public class JogadorRepository : Repository<Jogador>, IJogadorRepository
    {
        public JogadorRepository(EfDbContext efContext)
            : base(efContext)
        { }
    }
}
