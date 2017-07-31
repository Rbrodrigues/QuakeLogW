using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wunderman.QuakeLog.Core.Domain.Entities;
using Wunderman.QuakeLog.Core.Domain.Services;

namespace Wunderman.QuakeLog.Core.Services
{
    public class QuakeLogImportService : IQuakeLogImportService
    {
        private const string FILENAME = "quake.log";

        private IList<Partida> _partidas;

        private readonly IPartidaService _partidaService;

        public QuakeLogImportService(IPartidaService partidaService)
        {
            _partidaService = partidaService;
        }

        public void Import(string pathFile)
        {
            var partidas = QuakeLogRead(pathFile);

            if (partidas == null || partidas.Count <= 0) return;

            SalvarPartidas(partidas);
        }

        private IList<Partida> QuakeLogRead(string pathFile)
        {
            _partidas = new List<Partida>();

            if (!VerificarSeExisteDiretorioEArquivo(pathFile)) return null;

            using (var file = new StreamReader(string.Format("{0}\\{1}", pathFile, FILENAME)))
            {
                var line = file.ReadLine();

                Partida partida = null;

                while ((line = file.ReadLine()) != null)
                {
                    var identificador = ObterIdentificador(line);

                    var tipoRegistro = new TipoRegistro();

                    switch (identificador)
                    {
                        case "INITGAME":
                            tipoRegistro = TipoRegistro.InitGame;
                            break;
                        case "KILL":
                            tipoRegistro = TipoRegistro.Kill;
                            break;
                        case "CLIENTUSERINFOCHANGED":
                            tipoRegistro = TipoRegistro.ClientUserInfoChanged;
                            break;
                        default:
                            tipoRegistro = TipoRegistro.Invalido;
                            break;
                    }

                    line = string.Join(";", line.Split(':').Skip(2).ToArray());
                    
                    if (tipoRegistro == TipoRegistro.InitGame)
                        partida = AdicionarPartida(partida);

                    if (tipoRegistro == TipoRegistro.ClientUserInfoChanged)
                        AdicionarNovoJogador(line, partida);

                    if (tipoRegistro == TipoRegistro.Kill)
                        CalcularPontos(line, partida);
                }
                file.Close();
            }
            return _partidas;
        }

        private void CalcularPontos(string line, Partida partida)
        {
            if (line.Contains("<world>"))
            {
                PontuarMortePorCenario(line, partida);
            }
            else
            {
                PontuarEliminacao(line, partida);
                PontuarMorte(line, partida);
            }
        }

        private Partida AdicionarPartida(Partida partida)
        {
            if (partida != null)
                _partidas.Add(partida);

            return new Partida();
        }

        private static void AdicionarNovoJogador(string line, Partida partida)
        {
            var nome = line.Split('\\')[1].Trim();

            if (partida != null && partida.Jogadores != null)
            {

                if (!partida.Jogadores.Any(p => p.Nome == nome))
                    partida.Jogadores.Add(new Jogador(nome));
            }
        }

        private void PontuarEliminacao(string line, Partida partida)
        {
            var nome = partida.Jogadores.Where(p => line.Contains("; " + p.Nome)).Select(p => p.Nome).FirstOrDefault();
            partida.Jogadores.FirstOrDefault(p => p.Nome == nome).AdicionarEliminacao();
        }

        private void PontuarMorte(string line, Partida partida)
        {
            var nome = partida.Jogadores.Where(p => line.Contains(p.Nome + " by")).Select(p => p.Nome).FirstOrDefault();
            partida.Jogadores.FirstOrDefault(p => p.Nome == nome).AdicionarMorte();
        }

        private void PontuarMortePorCenario(string line, Partida partida)
        {
            var nome = partida.Jogadores.Where(p => line.Contains(p.Nome)).Select(p => p.Nome).FirstOrDefault();
            partida.Jogadores.FirstOrDefault(p => p.Nome == nome).AdicionarMortePorCenario();
        }

        private static string ObterIdentificador(string line)
        {
            return line.Substring(7, (line.Length - 7)).Split(':').FirstOrDefault().Trim().ToUpper();
        }

        private void SalvarPartidas(IList<Partida> partidas)
        {
            _partidaService.Salvar(partidas);
        }

        private bool VerificarSeExisteDiretorioEArquivo(string pathFile)
        {
            var valido = true;

            if (!Directory.Exists(pathFile)) valido = false;

            if (!File.Exists(string.Format("{0}\\{1}", pathFile, FILENAME))) valido = false;

            return valido;
        }
    }
}
