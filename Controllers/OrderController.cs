using Microsoft.AspNetCore.Mvc;

namespace mvcproject.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult ConfirmOrder()
        {
            //اتاكد ان الداتا داخلة كاملة ومظبوطة وانه مسجل
            //العناصر تتضاف في الاوردر ليست
            //العناصر تتمسح من الكارت
            //يوصل نتوفكيشن للادمن
           
            return View();
        }
        
        public IActionResult MakeOrder()
        {
            
           
            return View();
        }
    }
}
