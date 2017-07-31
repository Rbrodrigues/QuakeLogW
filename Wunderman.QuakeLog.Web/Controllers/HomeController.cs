using System.Web.Mvc;

namespace Wunderman.QuakeLog.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}