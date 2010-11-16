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
            return View(new NewEmployeeViewModel());
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public virtual ActionResult AddNew(NewEmployeeViewModel newEmployee)
        {
            commandBuilder.BuildCommand<AddEmployeeCommand>().Execute(newEmployee);
            return RedirectToAction("Created", newEmployee);
        }

        public virtual ActionResult Created(NewEmployeeViewModel newEmployee)
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
            commandBuilder.BuildCommand<SignOnEmployee>().Execute(newEmployeeId);
            return View();
        }
    }
}