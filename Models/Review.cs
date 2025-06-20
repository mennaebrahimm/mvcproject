using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public class Review
    {
        public int id { get; set; }
        public int rate { get; set; }

        public string comment { get; set; }

        public DateTime  createdAt { get; set; }= DateTime.UtcNow;

        //(product)1-m(reviews)
        [ForeignKey("product")]
        public int productId { get; set; }

        public Product product { get; set; }

        //(customer)1-m(reviews)
        [ForeignKey("customer")]
        public string customerId { get; set; }

        public ApplicationUser customer { get; set; }

    }
}
