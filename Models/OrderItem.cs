using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class OrderItem
    {
        public int id { get; set; }
        //public double UnitPrice { get; set; } // Price at time of purchase

        [ForeignKey("order")]
        public int orderId { get; set; }
        public virtual Order order { get; set; }


        [ForeignKey("product")]

        public int productId { get; set; }
        public virtual Product product { get; set; }
    }
}
