using System.Collections.Generic;
using System.Linq;
using Wunderman.QuakeLog.Core.Domain.Entities;
using Wunderman.QuakeLog.Core.Domain.Repositories;
using Wunderman.QuakeLog.Core.Domain.Services;

namespace Wunderman.QuakeLog.Core.Services
{
    public class PartidaService : IPartidaService
    {
        private readonly IPartidaRepository _partidaRepository;

        public PartidaService(IPartidaRepository partidaRepository)
        {
            _partidaRepository = partidaRepository;
        }
        
        public void Salvar(IList<Partida> partidas)
        {
            _partidaRepository.Add(partidas);
        }

        public IEnumerable<Partida> GetAll()
        {
            return _partidaRepository.GetAll();
        }

        public int TotalPartidas()
        {
            return _partidaRepository.GetAll().ToList().Count();
        }        
    }
}
