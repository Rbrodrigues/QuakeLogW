using System;
using System.Collections.Generic;
using System.Text;

namespace Wunderman.QuakeLog.Core.Domain.Entities
{
    public class Partida
    {
        public Partida()
        {
            Jogadores = new List<Jogador>();
        }

        public int PartidaId { get; set; }
        public virtual ICollection<Jogador> Jogadores { get; set; }
    }
}
