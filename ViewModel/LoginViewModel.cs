using System.ComponentModel.DataAnnotations;

namespace mvcproject.ViewModel
{
    public class LoginViewModel
    {
        public string userName {get; set;}

        [DataType(DataType.Password)]
        public string password {get; set;}

        [Display(Name ="Remember me")]
        public bool rememberMe {get; set;}
    }
}
