using System.ComponentModel.DataAnnotations;

namespace mvcproject.ViewModel
{
    public class AdminRegisterViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]

        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
