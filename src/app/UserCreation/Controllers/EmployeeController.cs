using System.Web.Mvc;
using UserCreation.Actions;
using UserCreation.ViewModels;

namespace UserCreation.Controllers
{
    [HandleError]
    public partial class EmployeeController : Controller
    {
        private readonly ICommandBuilder commandBuilder;

        public EmployeeController()
        {
            commandBuilder = new CommandBuilder();
        }

        public virtual ActionResult Add()
        {
            return View(new NewEmployee());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult AddNew(NewEmployee newEmployee)
        {
            commandBuilder.BuildCommand<AddEmployeeCommand>().Execute(newEmployee);
            return RedirectToAction("Created", newEmployee);
        }

        public virtual ActionResult Created(NewEmployee newEmployee)
        {
            return View(newEmployee);
        }

        public virtual ActionResult AllPending()
        {
            var pendingEmployees = commandBuilder.BuildCommand<GetAllPendingEmployees>().Execute();
            return View(pendingEmployees);
        }

        public virtual ActionResult SignOn(int newEmployeeId)
        {
            return View();
        }
    }
}