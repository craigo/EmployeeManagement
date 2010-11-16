using System.Web.Mvc;
using UserCreation.Actions;
using UserCreation.ViewModels;

namespace UserCreation.Controllers
{
    public partial class PayrollController : Controller
    {
        public virtual PartialViewResult BankInformation(int employeeId)
        {
            var employeePayrollInformation = new EmployeePayrollInformationViewModel();
            return PartialView(employeePayrollInformation);
        }

        public virtual PartialViewResult BankInformation(EmployeePayrollInformationViewModel employeePayrollInformation)
        {
            new CommandBuilder().BuildCommand<AddEmployeePayrollCommand>().Execute(employeePayrollInformation);
            return PartialView();
        }
    }
}