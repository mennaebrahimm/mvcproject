using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class Cart
    {
        public int id { get; set; }

        public bool isEmpty { get; set; }

        // 1-1 cart-customer
        [ForeignKey("customer")]
        public string customerId { get; set; }

        public virtual ApplicationUser customer { get; set; }

        public virtual List<CartItem> CartItems { get; set; }
    }
}
