namespace Wunderman.QuakeLog.Core.Domain.Reports
{
    public class RelatorioTotalPontosPorJogadorPartida
    {
        public int Partida { get; set; }
        public string Jogador { get; set; }
        public int TotalEliminacoes { get; set; }
        public int TotalMortes { get; set; }
    }
}
