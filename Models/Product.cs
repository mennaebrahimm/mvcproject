using System.ComponentModel.DataAnnotations.Schema;

namespace mvcproject.Models
{
    public enum ProductCategory
    {
        Fruits=0,
        Vegitables=1
    }
    public class Product
    { 
        public int id { get; set; }
        
        public string name { get; set; }

        public string imagePath { get; set; }

        public string description { get; set; }

        public ProductCategory category { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public bool isDeleted { get; set; }

        //1-m(reviews)
        public virtual List<Review> Reviews { get; set; }

        //(admin)1-m(products)
        [ForeignKey("admin")]
        public string adminId { get; set; }
        public ApplicationUser admin {  get; set; }
    }


}
