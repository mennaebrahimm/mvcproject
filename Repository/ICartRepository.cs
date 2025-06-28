using mvcproject.Models;

namespace mvcproject.Repository
{
    public interface ICartRepository:IRepository<Cart>
    {
        void Add(Cart cart);
      
         List<CartItemViewModel> GetCartItems(string userId);
         void ClearCart(string userId);
        

        void Save ();
    }
}
