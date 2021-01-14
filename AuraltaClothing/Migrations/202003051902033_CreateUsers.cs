namespace AuraltaClothing.Migrations
{
    using AuraltaClothing.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUsers : DbMigration
    {
        public override void Up()
        {

            // Initialize the managers for the users
            var store = new UserStore<ApplicationUser>(new AuraltaClothingDbContext());
            var manager = new UserManager<ApplicationUser>(store);

            var admin = new ApplicationUser
            {
                UserName = "admin", // This needs to be changed to admin@auralta-clothing.com manuely
                Email = "admin", // This needs to be changed to admin@auralta-clothing.com manuely
                FirstName = "Auralta",
                LastName = "Clothing",
                ShoppingCart = new Models.ShoppingCart()
            };

            manager.Create(admin, "##myX$nU3v");
            manager.AddToRole(admin.Id, Roles.Admin);

        }
        
        public override void Down()
        {
        }
    }
}
