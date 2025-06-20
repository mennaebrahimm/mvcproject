using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public enum OrderStatus
    {

        Processing = 0,        // Order being prepared for shipment
        Shipped = 1,           // All items shipped
        OutForDelivery = 2,    // With delivery carrier
        Delivered = 3,         // Customer received order
        Cancelled = 4,        // Order cancelled before shipping
        CancelledByAdmin = 5
    }
    public class Order
    {
        public int id { get; set; }
        public string notes { get; set; }

        public DateTime date { get; set; }

        public double total { get; set; }

        public string phoneNumber { get; set; }

        public OrderStatus status { get; set; }

        //orders(m)-1(promocode)
        [ForeignKey("promoCode")]
        public int promoCodeId { get; set; }
        public PromoCode promoCode { get; set; }
    }
}

