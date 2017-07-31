using System.Collections.Generic;
using Wunderman.QuakeLog.Core.Domain.Entities;

namespace Wunderman.QuakeLog.Core.Domain.Services
{
    public interface IPartidaService
    {
        void Salvar(IList<Partida> partidas);
        IEnumerable<Partida> GetAll();
        int TotalPartidas();
    }
}
