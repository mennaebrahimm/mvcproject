using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.Repository;
using mvcproject.ViewModel;
namespace mvcproject.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IAddressRepository _addressRepo;
        private readonly ICartRepository _cartRepo;

        public OrderController(IOrderRepository orderRepo, IAddressRepository addressRepo, ICartRepository cartRepo)
        {
            _orderRepo = orderRepo;
            _addressRepo = addressRepo;
            _cartRepo = cartRepo;
        }
       
        

            [HttpPost]
            public IActionResult MakeOrder(MakeOrderViewModel model)
            {
                var userId = User.FindFirst("sub")?.Value;
                int addressId;

                if (model.SelectedAddressId.HasValue)
                {
                    addressId = model.SelectedAddressId.Value;
                }
                else
                {
                    var newAddress = new Address
                    {
                        customerId = userId,
                        country = model.Country,
                        city = model.City,
                        area = model.Area,
                        street = model.Street,
                        buildingNumber = model.BuildingNumber,
                        phoneNumber = model.PhoneNumber,
                        isDeleted = false
                    };
                    addressId = _addressRepo.Add(newAddress).id;
                }

                var cartItems = _cartRepo.GetCartItems(userId);

                var order = new Order
                {
                    customerId = userId,
                    addressId = addressId,
                    date = DateTime.Now,
                    total = (double)model.Total,
                    status = OrderStatus.Processing,
                    phoneNumber = model.PhoneNumber,
                    OrderItems = cartItems.Select(c => new OrderItem
                    {
                        productId = c.ProductId
                    }).ToList()
                };

                _orderRepo.Add(order);
                _cartRepo.ClearCart(userId);

                return RedirectToAction("OrderSuccess");
            
                return View();
        }
   
        public IActionResult MakeOrder()
        {

           // var userId = User.FindFirst("sub")?.Value; // أو حسب نظامك
           string userId = "6";
            var model = new MakeOrderViewModel
            {
                CartItems = _cartRepo.GetCartItems(userId),
                SavedAddresses = _addressRepo.GetAddressesByUser(userId)
            };

            return View(model);
        }

    }


}
