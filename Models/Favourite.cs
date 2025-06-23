using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class Favourite
    {
        public int id { get; set; }

        public bool isEmpty { get; set; }
        // 1-1 favourite-customer
        [ForeignKey("customer")]
        public string customerId { get; set; }

        public  ApplicationUser customer { get; set; }

        public virtual List<FavouriteItem> FavouriteItems   { get; set; }
    }
}
