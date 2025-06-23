using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class FavouriteItem
    {
        public int id { get; set; }

        // Attributes
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;

        // relations

        [ForeignKey("favourite")]
        public int favouriteId { get; set; }
        public virtual Favourite favourite { get; set; }

        [ForeignKey("product")]
        public int productId { get; set; }
        public virtual Product product { get; set; }
    }
}
