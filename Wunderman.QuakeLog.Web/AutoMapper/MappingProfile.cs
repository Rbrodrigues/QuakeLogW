using AutoMapper;
using Wunderman.QuakeLog.Core.Domain.Reports;
using Wunderman.QuakeLog.Core.Domain.Entities;
using Wunderman.QuakeLog.Web.Models;

namespace Wunderman.QuakeLog.Web.AutoMapper
{
    public class MappingProfile: Profile
    {
        protected void Configure()
        {
            var config = new MapperConfiguration(cfg => {

                cfg.CreateMap<PartidaModel, Partida>();
                cfg.CreateMap<Partida, PartidaModel>();

                cfg.CreateMap<JogadorModel, Jogador>();
                cfg.CreateMap<Jogador, JogadorModel>();

                cfg.CreateMap<RelatorioTotalMortesPorPartida, RelatorioTotalMortesPorPartidaModel>();
                cfg.CreateMap<RelatorioTotalMortesPorPartidaModel, RelatorioTotalMortesPorPartida>();

                cfg.CreateMap<RelatorioTotalJogadoresPorPartidaModel, RelatorioTotalJogadoresPorPartida>();
                cfg.CreateMap<RelatorioTotalJogadoresPorPartida, RelatorioTotalJogadoresPorPartidaModel>();

                cfg.CreateMap<RelatorioTotalPontosPorJogadorPartidaModel, RelatorioTotalPontosPorJogadorPartida>();
                cfg.CreateMap<RelatorioTotalPontosPorJogadorPartida, RelatorioTotalPontosPorJogadorPartidaModel>();
            });
        }
    }
}