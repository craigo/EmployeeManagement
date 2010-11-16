using System.ComponentModel;

namespace UserCreation.ViewModels
{
    public class NewEmployeeViewModel
    {
        [DisplayName("First Name:")]
        public string FirstName { get; set; }

        [DisplayName("Last Name:")]
        public string LastName { get; set; }
    }
}