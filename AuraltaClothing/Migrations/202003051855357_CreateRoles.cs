namespace AuraltaClothing.Migrations
{
    using AuraltaClothing.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRoles : DbMigration
    {
        public override void Up()
        {

            // Role Creation
            var roleStore = new RoleStore<IdentityRole>(new AuraltaClothingDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            roleManager.Create(new IdentityRole(Roles.Admin));

        }
        
        public override void Down()
        {
        }
    }
}
