using System;
using System.Collections.Generic;
using System.Linq;
using Wunderman.QuakeLog.Core.Domain.Reports;
using Wunderman.QuakeLog.Core.Domain.Services;

namespace Wunderman.QuakeLog.Core.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IPartidaService _partidaService;
        private readonly IJogadorService _jogadorService;

        public RelatorioService(IPartidaService partidaService, IJogadorService jogadorService)
        {
            _partidaService = partidaService;
            _jogadorService = jogadorService;
        }

        public IList<RelatorioTotalJogadoresPorPartida> ObterRelatorioTotalJogadoresPorPartida()
        {
            var relatorioTotalJogadoresPorPartidaList = new List<RelatorioTotalJogadoresPorPartida>();

            relatorioTotalJogadoresPorPartidaList = (from jogador in _jogadorService.GetAll().ToList()
                                                     group jogador by jogador.PartidaId into p
                                                     select new RelatorioTotalJogadoresPorPartida
                                                     {
                                                         Partida = p.Key,
                                                         TotalJogadoresConectados = p.Count()
                                                     }).ToList();

            return relatorioTotalJogadoresPorPartidaList;
        }

        public IList<RelatorioTotalMortesPorPartida> ObterRelatorioTotalMortesPorPartida()
        {
            var relatorioTotalMortesPorPartida = new List<RelatorioTotalMortesPorPartida>();

            relatorioTotalMortesPorPartida = (from jogador in _jogadorService.GetAll().ToList()
                                              group jogador by jogador.PartidaId into p
                                              select new RelatorioTotalMortesPorPartida
                                              {
                                                  Partida = p.Key,
                                                  TotalMortes = p.Sum(x => x.QuantidadeMortes)
                                              }).ToList();


            return relatorioTotalMortesPorPartida;
        }

        public IList<RelatorioTotalPontosPorJogadorPartida> ObterRelatorioTotalPontosPorJogadorPartida()
        {
            var relatorioTotalPontosPorJogadorPartida = new List<RelatorioTotalPontosPorJogadorPartida>();

            relatorioTotalPontosPorJogadorPartida = (from jogador in _jogadorService.GetAll().ToList()
                                              group jogador by new { jogador.PartidaId, jogador.Nome} into p
                                              select new RelatorioTotalPontosPorJogadorPartida
                                              {
                                                  Partida = p.Key.PartidaId,
                                                  Jogador = p.Key.Nome,
                                                  TotalMortes = p.Sum(x => x.QuantidadeMortes),
                                                  TotalEliminacoes = p.Sum(x => x.QuantidadeEliminacoes)
                                              }).ToList();


            return relatorioTotalPontosPorJogadorPartida;
        }

        public int TotalPartidas()
        {
            return _partidaService.TotalPartidas();
        }
    }
}
