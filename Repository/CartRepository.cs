using Microsoft.EntityFrameworkCore;
using mvcproject.Models;

namespace mvcproject.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ProjectContext context;
        public CartRepository(ProjectContext context)
        {
            this.context = context;
        }

        public async Task CreateCartAsync(string userId)
        {
            var cart = new Cart
            {
                customerId = userId,
                isEmpty = true
            };

            context.Carts.Add(cart);
            await context.SaveChangesAsync();


        }
        public async Task<Cart?> GetCartByUserIdAsync(string userId)
        {
            return await context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(i => i.product)
                .FirstOrDefaultAsync(c => c.customerId == userId);
        }


        public async Task AddItemToCartAync(string userId, int productId)
        {
            Cart cart = await GetCartByUserIdAsync(userId);
            cart.isEmpty = false;
            CartItem cartItem = cart.CartItems.FirstOrDefault(i => i.productId == productId);
            Product product = await context.Products.FindAsync(productId);
            if (product == null || product.quantity <= 0 || product.isDeleted)
            {
                return;
            }
            if (cartItem != null)
            {
                cartItem.quantity += 1;
            }
            else
            {
                cartItem = new CartItem
                {
                    productId = productId,
                    quantity = 1,
                    unitPrice = (decimal)product.price,
                    cartId = cart.id,
                    addedAt = DateTime.Now

                };
                cart.CartItems.Add(cartItem);


            }

            product.quantity -= 1;
            await SaveAsync();
        }

        public async Task DecreaseQuantityAsync(string userId, int productId)
        {
            Cart cart = await GetCartByUserIdAsync(userId);
            CartItem cartItem = cart.CartItems.FirstOrDefault(i => i.productId == productId);
            Product product = await context.Products.FindAsync(productId);

            if (cartItem != null && cartItem.quantity > 1)
            {
                cartItem.quantity -= 1;

            }
            else if (cartItem != null)
            {
                context.CartItems.Remove(cartItem);

            }
            if (!product.isDeleted)
            {
                product.quantity += 1;
            }
            await SaveAsync();
        }

        public async Task IncreaseQuantityAsync(string userId, int productId)
        {
            Cart cart = await GetCartByUserIdAsync(userId);
            CartItem cartItem = cart.CartItems.FirstOrDefault(i => i.productId == productId);
            Product product = await context.Products.FindAsync(productId);
            if (cartItem != null && product != null && product.quantity > 0 && !product.isDeleted)
            {
                cartItem.quantity += 1;
                product.quantity -= 1;
                await SaveAsync();
            }

        }

        public async Task<decimal> GetTotalPriceAsync(string userId)
        {
            Cart cart = await GetCartByUserIdAsync(userId);
            return cart.CartItems.Sum(i => i.quantity * i.unitPrice);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task RemoveItemFromCartAsync(string userId, int productId)
        {
            Cart cart = await GetCartByUserIdAsync(userId);
            CartItem cartItem = cart.CartItems.FirstOrDefault(i => i.productId == productId);
            Product product = await context.Products.FindAsync(productId);


            if (cartItem != null && product != null)
            {
                if (!product.isDeleted)
                {
                    product.quantity += cartItem.quantity;
                }

                context.CartItems.Remove(cartItem);
                await SaveAsync();
            }
            if (cart.CartItems == null || !cart.CartItems.Any())
            {
                cart.isEmpty = true;
                await SaveAsync();
            }
        }

        public async Task ClearCartAsync(string userId)
        {
            Cart cart = await GetCartByUserIdAsync(userId);
            var items = cart.CartItems.ToList();
            foreach (var item in items)
            {
                await RemoveItemFromCartAsync(userId, item.productId);
            }

        }

        #region make cart clear
        public void ClearCart(string userId)
        {
            var cartId = context.Carts
                .Where(c => c.customerId == userId)
                .Select(c => c.id)
                .FirstOrDefault();

            var items = context.CartItems.Where(c => c.cartId == cartId);
            context.CartItems.RemoveRange(items);
        }
        #endregion
        #region list of cart items
        public List<CartItemViewModel> GetCartItems(string userId)
        {
            var cartId = context.Carts
                .Where(c => c.customerId == userId)
                .Select(c => c.id)
                .FirstOrDefault();

            if (cartId == 0)
                return new List<CartItemViewModel>();

            var items = context.CartItems
                .Where(ci => ci.cartId == cartId)
                .Include(ci => ci.product) // علشان تجيب بيانات المنتج
                .Select(ci => new CartItemViewModel
                {
                    ProductId = ci.productId,
                    ProductName = ci.product.name,
                    ImageUrl = ci.product.imagePath, // لو عندك صورة
                    Quantity = ci.quantity,
                    UnitPrice = ci.unitPrice
                })
                .ToList();

            return items;
        }

        #endregion


    }
}
