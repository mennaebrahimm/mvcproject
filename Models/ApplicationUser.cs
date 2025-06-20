using Microsoft.AspNetCore.Identity;

namespace mvcproject.Models
{
    public class ApplicationUser: IdentityUser
    {
        //shared with admin - customer
        public string firstName { get; set; }
        public string lastName { get; set; }

        //-------customer relations--------//
        //(customer)1-m(reviews)
        public virtual List<Review> reviews { get; set; }


        //-------admin relations--------//
        //(admin)1-m(products)
        public virtual List<Product> products { get; set; }


    }
}
