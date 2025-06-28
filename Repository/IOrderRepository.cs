using mvcproject.Models;

namespace mvcproject.Repository
{
    public interface IOrderRepository : IRepository<Order>
    {

        void Add(Order order);  

        void Save();
    }
}
