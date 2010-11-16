using System.ComponentModel;
using MvcContrib.UI.InputBuilder.Attributes;

namespace UserCreation.ViewModels
{
    public class EmployeePayrollInformationViewModel
    {
        public int  EmployeeIdType { get; set; }

        [DisplayName("Bank Name:")]
        public string BankName { get; set; }
        [DisplayName("Transit Number:")]
        public string TransitNumber { get; set; }
        [DisplayName("Account Number:")]
        public string AccountNumber { get; set; }
    }
}