using mvcproject.Models;

namespace mvcproject.Repository
{
    public interface ICartRepository:IRepository<Cart>
    {
        Task<Cart> GetCartByUserIdAsync(string userId);
        Task CreateCartAsync(string userId);
        Task AddItemToCartAync(string userId, int productId);
        Task RemoveItemFromCartAsync(string userId, int productId);
        Task ClearCartAsync(string userId);
        Task DecreaseQuantityAsync(string userId, int productId);
        Task IncreaseQuantityAsync(string userId, int productId);
        Task<decimal> GetTotalPriceAsync(string userId);
    }
}
