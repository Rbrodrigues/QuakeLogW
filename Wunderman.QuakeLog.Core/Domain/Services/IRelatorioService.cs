using System.Collections.Generic;
using Wunderman.QuakeLog.Core.Domain.Reports;

namespace Wunderman.QuakeLog.Core.Domain.Services
{
    public interface IRelatorioService
    {
        int TotalPartidas();
        IList<RelatorioTotalMortesPorPartida> ObterRelatorioTotalMortesPorPartida();
        IList<RelatorioTotalJogadoresPorPartida> ObterRelatorioTotalJogadoresPorPartida();
        IList<RelatorioTotalPontosPorJogadorPartida> ObterRelatorioTotalPontosPorJogadorPartida();
    }
}
