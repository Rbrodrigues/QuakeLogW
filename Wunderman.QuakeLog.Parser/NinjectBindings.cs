using Ninject.Modules;
using Wunderman.QuakeLog.Core.Data.EfContext;
using Wunderman.QuakeLog.Core.Data.Repositories;
using Wunderman.QuakeLog.Core.Domain.Repositories;
using Wunderman.QuakeLog.Core.Domain.Services;
using Wunderman.QuakeLog.Core.Services;

namespace Wunderman.QuakeLog.Parser
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<EfDbContext>().To<EfDbContext>();
            Bind<IPartidaRepository>().To<PartidaRepository>();
            Bind<IPartidaService>().To<PartidaService>();
            Bind<IJogadorRepository>().To<JogadorRepository>();
            Bind<IJogadorService>().To<JogadorService>();
            Bind<IQuakeLogImportService>().To<QuakeLogImportService>();
            Bind<IRelatorioService>().To<RelatorioService>();
        }
    }
}
