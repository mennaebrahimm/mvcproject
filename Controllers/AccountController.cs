using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;

namespace mvcproject.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            ApplicationUser user;
            return View();
        }
    }
}
