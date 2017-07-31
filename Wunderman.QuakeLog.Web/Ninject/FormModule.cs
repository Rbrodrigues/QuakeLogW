using Ninject.Modules;
using Wunderman.QuakeLog.Core.Data.Repositories;
using Wunderman.QuakeLog.Core.Domain.Repositories;
using Wunderman.QuakeLog.Core.Domain.Services;
using Wunderman.QuakeLog.Core.Services;

namespace Wunderman.QuakeLog.Web.Ninject
{
    public class FormModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IPartidaService>().To<PartidaService>();
            Bind<IPartidaRepository>().To<PartidaRepository>();
            Bind<IQuakeLogImportService>().To<QuakeLogImportService>();
            Bind<IRelatorioService>().To<RelatorioService>();
        }
    }
}