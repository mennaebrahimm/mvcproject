using Microsoft.AspNetCore.Mvc;

namespace mvcproject.Controllers
{
    public class OrderController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
