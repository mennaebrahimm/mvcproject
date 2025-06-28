using System.ComponentModel.DataAnnotations;

namespace mvcproject.ViewModel
{
    public class RegisterUserWithAddressViewModel
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

        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Add Address")]
        public bool AddAddress { get; set; }

        [Display(Name = "Country")]
        public string? country { get; set; }
        [Display(Name = "City")]
        public string ?city { get; set; }
        [Display(Name = "Area")]
        public string ?area { get; set; }

        [Display(Name = "Street")]
        public string ?street { get; set; }

        [Display(Name = "Building Number")]

        public int? buildingNumber { get; set; }

        [Display(Name = "Phone Number")]

        public string? phoneNumber { get; set; }

        public bool? isDeleted { get; set; }

        public string? customerId { get; set; }
    }
}
