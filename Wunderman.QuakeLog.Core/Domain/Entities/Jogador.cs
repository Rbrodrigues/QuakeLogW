using System;
using System.Collections.Generic;
using System.Text;

namespace Wunderman.QuakeLog.Core.Domain.Entities
{
    public class Jogador
    {
        public Jogador() { }

        public Jogador(string nome, int quantidadeEliminacoes = 0, int quantidadeMortes = 0)
        {
            Nome = nome;
            QuantidadeEliminacoes = quantidadeEliminacoes;
            QuantidadeMortes = quantidadeMortes;
        }
        public int JogadorId { get; set; }
        public string Nome { get; private set; }
        public int QuantidadeEliminacoes { get; private set; }
        public int QuantidadeMortes { get; private set; }
        public int PartidaId { get; set; }
        public virtual Partida Partida { get; set; }


        public void AdicionarEliminacao()
        {
            QuantidadeEliminacoes++;
        }

        public void AdicionarMorte()
        {
            QuantidadeMortes++;
        }

        public void AdicionarMortePorCenario()
        {
            QuantidadeEliminacoes--;
        }
    }
}
