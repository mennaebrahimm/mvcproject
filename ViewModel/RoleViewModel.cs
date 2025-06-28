using System.ComponentModel.DataAnnotations;

namespace mvcproject.ViewModel
{
    public class RoleViewModel
    {
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
