using System.ComponentModel;

namespace UserCreation.ViewModels
{
    public class NewEmployee
    {
        [DisplayName("First Name:")]
        public string FirstName { get; set; }

        [DisplayName("Last Name:")]
        public string LastName { get; set; }
    }
}