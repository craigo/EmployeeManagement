using System.Web.Mvc;
using UserCreation.ViewModels;

namespace UserCreation.Controllers
{
    [HandleError]
    public class Employee : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Add()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Add(NewEmployee newEmployee)
        {
            return Redirect("EmployeeAdded");
        }
    }
}