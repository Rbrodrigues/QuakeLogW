using AutoMapper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Wunderman.QuakeLog.Core.Domain.Reports;
using Wunderman.QuakeLog.Core.Domain.Services;
using Wunderman.QuakeLog.Web.Models;

namespace Wunderman.QuakeLog.Web.Controllers
{
    public class RelatorioController : Controller
    {
        private IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }


        // GET: Relatorio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RelatorioQtasPartidas()
        {
            try
            {
                var relatorio = _relatorioService.TotalPartidas();
                return View("RelatorioQtasPartidas.cshtml", relatorio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult RelatorioTotaldeMortesPorPartida()
        {
            try
            { 
                var relatorio = Mapper.Map<IEnumerable<RelatorioTotalMortesPorPartida>,IEnumerable<RelatorioTotalMortesPorPartidaModel>>(_relatorioService.ObterRelatorioTotalMortesPorPartida());
                return View("RelatorioTotaldeMortesPorPartida.cshtml", relatorio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult RelatorioQtosJogadoresConectaram()
        {
            try
            {
                var relatorio = Mapper.Map<IEnumerable<RelatorioTotalJogadoresPorPartida>, IEnumerable<RelatorioTotalJogadoresPorPartidaModel>>(_relatorioService.ObterRelatorioTotalJogadoresPorPartida());
                return View("RelatorioQtosJogadoresConectaram.cshtml",relatorio);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult RelatorioMortesCausadasSofridas()
        {
            try
            {
                var relatorio = Mapper.Map<IEnumerable<RelatorioTotalPontosPorJogadorPartida>, IEnumerable<RelatorioTotalPontosPorJogadorPartidaModel>>(_relatorioService.ObterRelatorioTotalPontosPorJogadorPartida());
                return View("RelatorioMortesCausadasSofridas.cshtml", relatorio);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}