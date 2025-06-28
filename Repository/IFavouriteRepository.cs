using mvcproject.Models;

namespace mvcproject.Repository
{
    public interface IFavouriteRepository:IRepository<Favourite>
    {
        Task<Favourite> GetWishListByUserIdAsync(string userId);
        Task CreateWishListAsync(string userId);
        Task AddToWishListAsync(string userId, int productId);
        Task RemoveFromWishListAsync(string userId, int productId);
        Task ClearWishListAsync(string userId);
        Task SaveAsync();
        
    }
}
