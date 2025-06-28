using mvcproject.Models;

namespace mvcproject.Repository
{
    public interface ICartRepository:IRepository<Cart>
    {
        void Add(Cart cart);
        void Save ();
    }
}
