using System.Web.Mvc;
using UserCreation.Actions;
using UserCreation.ViewModels;

namespace UserCreation.Controllers
{
    [HandleError]
    public class EmployeeController : Controller
    {
        private readonly ICommandBuilder commandBuilder;

        public EmployeeController()
        {
            commandBuilder = new CommandBuilder();
        }

        public ActionResult Add()
        {
            return View(new NewEmployee());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult AddNew(NewEmployee newEmployee)
        {
            commandBuilder.BuildCommand<AddEmployeeCommand>().Execute(newEmployee);
            return RedirectToAction("Created", newEmployee);
        }

        public ActionResult Created(NewEmployee newEmployee)
        {
            return View(newEmployee);
        }

        public ActionResult AllPending()
        {
            var pendingEmployees = commandBuilder.BuildCommand<GetAllPendingEmployees>().Execute();
            return View(pendingEmployees);
        }
    }
}