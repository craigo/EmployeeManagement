using System.Web.Mvc;

namespace UserCreation.Controllers
{
    [HandleError]
    public class EmployeeAdded : Controller
    {
        public ViewResult Complete()
        {
            return View();
        }
    }
}