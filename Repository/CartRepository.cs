using mvcproject.Models;

namespace mvcproject.Repository
{
    public class CartRepository:ICartRepository
    {
        ProjectContext Context;

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

        #region Save Changes
        public void Save()
        {
            Context.SaveChanges();
        }
        #endregion
    }
}
