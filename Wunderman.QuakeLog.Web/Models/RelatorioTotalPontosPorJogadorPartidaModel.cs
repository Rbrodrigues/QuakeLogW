namespace Wunderman.QuakeLog.Web.Models
{
    public class RelatorioTotalPontosPorJogadorPartidaModel
    {
        public int Partida { get; set; }
        public string Jogador { get; set; }
        public int TotalEliminacoes { get; set; }
        public int Totalmortes { get; set; }
    }
}