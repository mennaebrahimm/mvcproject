using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcproject.Models;
using mvcproject.Repository;

namespace mvcproject.Controllers
{
    [Authorize(Roles = "Customer")]
    public class FavouriteController : Controller
    {
        private readonly IFavouriteRepository favouriteRepository;
        public FavouriteController(IFavouriteRepository favouriteRepository)
        {
            this.favouriteRepository = favouriteRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Favourite favourite = await favouriteRepository.GetWishListByUserIdAsync(userId);
            return View(favourite);
        }
        public async Task<IActionResult> Add(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await favouriteRepository.AddToWishListAsync(userId, productId);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> Remove(int productId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await favouriteRepository.RemoveFromWishListAsync(userId, productId);
            Favourite updateFavourite = await favouriteRepository.GetWishListByUserIdAsync(userId);
            return View("index", updateFavourite);
        }
        public async Task<IActionResult> Clear()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await favouriteRepository.ClearWishListAsync(userId);
            Favourite updateFavourite = await favouriteRepository.GetWishListByUserIdAsync(userId);
            return View("index", updateFavourite);
        }
    }
}
