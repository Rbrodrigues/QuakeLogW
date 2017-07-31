using System.Collections.Generic;
using Wunderman.QuakeLog.Core.Domain.Entities;
using Wunderman.QuakeLog.Core.Domain.Repositories;
using Wunderman.QuakeLog.Core.Domain.Services;

namespace Wunderman.QuakeLog.Core.Services
{
    public class JogadorService : IJogadorService
    {        
        private readonly IJogadorRepository _jogadorRepository;

        public JogadorService(IJogadorRepository jogadorRepository)
        {
            _jogadorRepository = jogadorRepository;     
        }

        public IEnumerable<Jogador> GetAll()
        {
            return _jogadorRepository.GetAll();
        }        
    }
}
