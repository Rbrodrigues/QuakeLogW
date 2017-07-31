using Wunderman.QuakeLog.Web.AutoMapper;

namespace Wunderman.QuakeLog.Web.App_Start
{
    public class Bootstrapper
    {
        public static void Run()
        {
            AutoMapperConfig.Configure();
        }
    }
}