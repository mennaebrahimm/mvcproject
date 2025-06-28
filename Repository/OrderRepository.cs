using mvcproject.Models;

namespace mvcproject.Repository
{
    public class OrderRepository : IOrderRepository
    {

        private readonly ProjectContext _context;
        public OrderRepository(ProjectContext _Context)
        {
            _context = _Context;
        }
        #region AddOrder
        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }
        #endregion

        #region Save
        public void Save()
        {
            _context.SaveChanges();
        }
        #endregion



    }
}
