using System.Web.Mvc;
using UserCreation.Actions;
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
            new AddEmployeeCommand().Execute(newEmployee);
            return RedirectToAction("Created", newEmployee);
        }

        public ActionResult Created(NewEmployee newEmployee)
        {
            return View(newEmployee);
        }
    }
}