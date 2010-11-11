using System.Web.Mvc;

namespace web.Controllers
{
    [HandleError]
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public virtual ActionResult About()
        {
            return View();
        }
    }
}
