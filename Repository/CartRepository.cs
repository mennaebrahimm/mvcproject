using Microsoft.EntityFrameworkCore;
using mvcproject.Models;

namespace mvcproject.Repository
{
    public class CartRepository:ICartRepository
    {
        private readonly ProjectContext Context;

        public CartRepository(ProjectContext context)
        {
                Context=context;
        }

        #region Add cart
        public void Add(Cart cart)
        {
            Context.Carts.Add(cart);
        }
        #endregion
        #region make cart clear
        public void ClearCart(string userId)
        {
            var cartId = Context.Carts
                .Where(c => c.customerId == userId)
                .Select(c => c.id)
                .FirstOrDefault();

            var items = Context.CartItems.Where(c => c.cartId == cartId);
            Context.CartItems.RemoveRange(items);
        }
        #endregion
        #region list of cart items
        public List<CartItemViewModel> GetCartItems(string userId)
        {
            var cartId = Context.Carts
                .Where(c => c.customerId == userId)
                .Select(c => c.id)
                .FirstOrDefault();

            if (cartId == 0)
                return new List<CartItemViewModel>();

            var items = Context.CartItems
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

        #region Save Changes
        public void Save()
        {
            Context.SaveChanges();
        }
        #endregion
    }
}
