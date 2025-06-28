using Microsoft.EntityFrameworkCore;
using mvcproject.Models;

namespace mvcproject.Repository
{
    public class FavouriteRepository : IFavouriteRepository
    {
        private readonly ProjectContext context;
        public FavouriteRepository(ProjectContext context)
        {
            this.context = context;
        }

        public async Task AddToWishListAsync(string userId, int productId)
        {
            Favourite favourite = await GetWishListByUserIdAsync(userId);
            favourite.isEmpty = false;
            FavouriteItem favouriteItem = favourite.FavouriteItems.FirstOrDefault(i => i.productId == productId);
            if (favouriteItem == null)
            {
                var newItem = new FavouriteItem
                {
                    productId = productId,
                    favouriteId = favourite.id
                };
                favourite.FavouriteItems.Add(newItem);
                await SaveAsync();
            }
        }

        public async Task ClearWishListAsync(string userId)
        {
            Favourite favourite = await GetWishListByUserIdAsync(userId);
            var items = favourite.FavouriteItems.ToList();
            foreach (var item in items)
            {
                await RemoveFromWishListAsync(userId, item.productId);
            }
            favourite.isEmpty = true;
        }

        public async Task<Favourite?> GetWishListByUserIdAsync(string userId)
        {
            return await context.Favourites
                .Include(f => f.FavouriteItems)
                .ThenInclude(i => i.product)
                .FirstOrDefaultAsync(f => f.customerId == userId);
        }
        private readonly  ProjectContext Context;

        public async Task CreateWishListAsync(string userId)
        {
            var favourite = new Favourite
            {
                customerId = userId,
                isEmpty = true,
                
            };

            context.Favourites.Add(favourite);
            await context.SaveChangesAsync();

            
        }
        

        public async Task RemoveFromWishListAsync(string userId, int productId)
        {
            Favourite favourite = await GetWishListByUserIdAsync(userId);
            var item = favourite.FavouriteItems.FirstOrDefault(i => i.productId == productId);
            if (item != null)
            {
                context.FavouriteItems.Remove(item);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
