using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.Repository;

namespace mvcproject.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartController : Controller
    {
        ICartRepository cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Cart cart = await cartRepository.GetCartByUserIdAsync(userId);

            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await cartRepository.AddItemToCartAync(userId, productId);

            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Increase(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await cartRepository.IncreaseQuantityAsync(userId, productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Decrease(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await cartRepository.DecreaseQuantityAsync(userId, productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await cartRepository.RemoveItemFromCartAsync(userId, productId);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Clear()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await cartRepository.ClearCartAsync(userId);
            return RedirectToAction("Index");
        }

        public async Task<decimal> GetTotal()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await cartRepository.GetTotalPriceAsync(userId);
        }
    }
}
