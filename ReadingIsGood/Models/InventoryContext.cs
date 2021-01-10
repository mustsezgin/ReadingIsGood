using Microsoft.EntityFrameworkCore;
using System;

namespace ReadingIsGood.Models
{
    public partial class InventoryContext : DbContext
    {

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {

        }

        public virtual DbSet<InventoryItem> InventoryItem { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<SalesOrder> SalesOrder { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<InventoryItem>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InventoryItem)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_pro_inv");
            });



            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
                entity.Property(e => e.IsActive).HasDefaultValue(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<SalesOrder>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_pro_sal");
                
                entity.HasOne(d => d.UserInfo)
                    .WithMany(p => p.SalesOrder)
                    .HasForeignKey(d => d.UserInfoUserId)
                    .HasConstraintName("fk_usr_sal");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CC4CF55D88A1");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            #region SeedData

            var product1 = new Product
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Name = "The Hitchhiker's Guide to the Galaxy",
                ProductCode = "Book1"
            };
            var product2 = new Product
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Name = "The Lord of the Rings Trilogy",
                ProductCode = "Book2"
            };
            var product3 = new Product
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Name = "The Pearl",
                ProductCode = "Book3"
            };
            var product4 = new Product
            {
                Id = Guid.NewGuid(),
                IsActive = true,
                Name = "The Hobbit",
                ProductCode = "Book4"
            };
            modelBuilder.Entity<Product>().HasData(product1, product2, product3, product4);

            var inventoryItem1 = new InventoryItem
            {
                Id = Guid.NewGuid(),
                ProductId = product1.Id,
                Quantity = 25,
            };
            var inventoryItem2 = new InventoryItem
            {
                Id = Guid.NewGuid(),
                ProductId = product2.Id,
                Quantity = 45,
            };
            var inventoryItem3 = new InventoryItem
            {
                Id = Guid.NewGuid(),
                ProductId = product3.Id,
                Quantity = 15,
            };
            var inventoryItem4 = new InventoryItem
            {
                Id = Guid.NewGuid(),
                ProductId = product4.Id,
                Quantity = 5,
            };

            modelBuilder.Entity<InventoryItem>().HasData(inventoryItem1, inventoryItem2, inventoryItem3, inventoryItem4);

            var user1 = new UserInfo
            {
                UserId = Guid.NewGuid(),
                Email = "mustsezgin@yahoo.com",
                Password = "1",
                FirstName = "Mustafa",
                LastName = "Sezgin",
                CreatedDate = DateTime.Now,
                Role = "Operator",
                UserName = "msezgin",
                Address = "Ankara"
            };
            var user2 = new UserInfo
            {
                UserId = Guid.NewGuid(),
                Email = "hankmoody@moody.de",
                Password = "1",
                FirstName = "Hank",
                LastName = "Moody",
                CreatedDate = DateTime.Now,
                Role = "Customer",
                UserName = "hankmoody",
                Address = "California"
            };
            modelBuilder.Entity<UserInfo>().HasData(user1, user2);

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
