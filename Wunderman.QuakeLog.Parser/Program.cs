using Ninject;
using System;
using System.Reflection;
using Wunderman.QuakeLog.Core.Domain.Services;

namespace Wunderman.QuakeLog.Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardKernel kernel = new StandardKernel();

            kernel.Load(Assembly.GetExecutingAssembly());

            IQuakeLogImportService logImport = kernel.Get<IQuakeLogImportService>();

            logImport.Import("C:\\log");

            Console.WriteLine("Importado!!!");

            IRelatorioService report = kernel.Get<IRelatorioService>();

            var TotalPartidas = report.TotalPartidas();
            Console.WriteLine("TotalPartidas => " + TotalPartidas.ToString());

            var relatorioTotalJogadoresPorPartida = report.ObterRelatorioTotalJogadoresPorPartida();
            Console.WriteLine("**** Relatorio RelatorioTotalJogadoresPorPartida ****");
            foreach (var item in relatorioTotalJogadoresPorPartida)
            {
                Console.WriteLine("Partida: " + item.Partida.ToString() + " TotalJogadores: " + item.TotalJogadoresConectados);
            }
            Console.WriteLine("**** Relatorio RelatorioTotalJogadoresPorPartida END ****");

            var relatorioTotalMortesPorPartida = report.ObterRelatorioTotalMortesPorPartida();
            Console.WriteLine("**** Relatorio RelatorioTotalMortesPorPartida ****");
            foreach (var item in relatorioTotalMortesPorPartida)
            {
                Console.WriteLine("Partida: " + item.Partida.ToString() + " TotalMortes: " + item.TotalMortes);
            }
            Console.WriteLine("**** Relatorio RelatorioTotalMortesPorPartida END ****");

            var relatorioTotalPontosPorJogadorPartida = report.ObterRelatorioTotalPontosPorJogadorPartida();
            Console.WriteLine("**** Relatorio RelatorioTotalPontosPorJogadorPartida ****");
            foreach (var item in relatorioTotalPontosPorJogadorPartida)
            {
                Console.WriteLine("Partida: " + item.Partida.ToString() + " Jogador: " + item.Jogador + " TotalEliminacoes: " + item.TotalEliminacoes + " Totalmortes: " + item.TotalMortes);
            }
            Console.WriteLine("**** Relatorio RelatorioTotalPontosPorJogadorPartida END ****");



            Console.ReadKey();
        }
    }
}
