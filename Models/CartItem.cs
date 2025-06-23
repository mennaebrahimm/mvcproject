using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class CartItem 
    {
        public int id { get; set; }

        // Attributes
        public int quantity { get; set; } = 1;
        public decimal unitPrice { get; set; } // Price snapshot
        public DateTime addedAt { get; set; } = DateTime.UtcNow;

        // relations 

        [ForeignKey("cart")]
        public int cartId { get; set; }
        public virtual Cart cart { get; set; }

        [ForeignKey("product")]

        public int productId { get; set; }

        public virtual Product product { get; set; }

    }
}
