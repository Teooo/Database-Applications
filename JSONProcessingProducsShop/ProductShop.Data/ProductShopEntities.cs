namespace ProductShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ProductShop.Models;
    using ProductShop.Data.Migrations;

    public class ProductShopEntities : DbContext
    {
        
        public ProductShopEntities()
            : base("name=ProductShopEntities")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductShopEntities, Configuration>());
        }

        public virtual IDbSet<User> Users{ get; set; }

        public virtual IDbSet<Product> Products { get; set; }

        public virtual  IDbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Friends).WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                        
                });
            modelBuilder.Entity<Product>()
                .HasRequired(s => s.Seller)
                .WithMany(sp => sp.SellingProducts)
                .HasForeignKey(k => k.SellerId)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Product>()
                .HasOptional(b => b.Buyer)
                .WithMany(bp => bp.BoughtProducts)
                .HasForeignKey(k => k.BuyerId)
                .WillCascadeOnDelete(false);
           
            base.OnModelCreating(modelBuilder);
        }
    }

   
}