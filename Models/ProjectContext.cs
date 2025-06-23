using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace mvcproject.Models
{
    public class ProjectContext: IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }          
        public virtual DbSet<PromoCode> PromoCodes { get; set; }

        public virtual DbSet<Order> Orders { get; set; }    

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<Favourite> Favourites { get; set; }    

        public virtual DbSet<Cart> Carts { get; set; }                  

        public virtual DbSet<Address> Addresses { get; set; }     

        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<FavouriteItem> FavouriteItems { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {

        }
        
    }
}
