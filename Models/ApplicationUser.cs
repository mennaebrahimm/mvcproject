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

        //(customer)1-m(addresses)
        public virtual List<Address> addresses { get; set; }

        //(customer)1-m(orders)
        public virtual List<Order> Orders { get; set; }
        // (customer)1-m(notification)
        public virtual List<Notification>  Notifications { get; set; }

        // 1-to-1 Navigation Properties
        public virtual Cart Cart { get; set; }
        public virtual Favourite Favourite { get; set; }

        



        //-------admin relations--------//
        //(admin)1-m(products)
        //public virtual List<Product> products { get; set; }
        //there is only one admin in this project so we don't need this relation

    }
}
