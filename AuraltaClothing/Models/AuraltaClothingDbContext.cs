using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AuraltaClothing.Models
{

    public class AuraltaClothingDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuraltaClothingDbContext()
            : base("AuraltaClothingConnection", throwIfV1Schema: false)
        {
        }

        public static AuraltaClothingDbContext Create()
        {
            return new AuraltaClothingDbContext();
        }

        public virtual DbSet<Subscription> Subscriptions { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductImage> ProductImages { get; set; }

        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public virtual DbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<ProductOrder> ProductOrders { get; set; }

        public virtual DbSet<Message> Messages { get; set; }



    }
}