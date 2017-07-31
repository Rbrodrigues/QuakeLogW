using System.Collections.Generic;
using Wunderman.QuakeLog.Core.Domain.Entities;

namespace Wunderman.QuakeLog.Core.Domain.Services
{
    public interface IJogadorService
    {
        IEnumerable<Jogador> GetAll();
    }
}
