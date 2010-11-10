using System.Web.Mvc;
using UserCreation.ViewModels;

namespace UserCreation.Controllers
{
    [HandleError]
    public class EmployeeController : Controller
    {
        public ActionResult Add()
        {
            return View(new NewEmployee());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddNew(NewEmployee newEmployee)
        {
            return Redirect("EmployeeAdded");
        }
    }
}