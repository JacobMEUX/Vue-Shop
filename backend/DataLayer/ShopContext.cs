using DataLayer.Entities;
using DataLayer.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class ShopContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Image> Images { get; set; }


        public ShopContext(DbContextOptions<ShopContext> optionsBuilder) : base(optionsBuilder)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasKey(o => o.BrandId);
            modelBuilder.Entity<Category>().HasKey(o => o.CategoryId);
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Clothing>().HasKey(o => o.ClothingId);
            modelBuilder.Entity<Costumer>().HasKey(o => o.CostumerId);
            modelBuilder.Entity<OrderLine>().HasKey(o => new { o.FKClothingId, o.FKOrderId });

            modelBuilder.Entity<Clothing>().HasOne(o => o.Category).WithMany(o => o.Clothing).HasForeignKey(o => o.FKCategoryId);
            modelBuilder.Entity<Clothing>().HasOne(o => o.Brand).WithMany(o => o.Clothing).HasForeignKey(o => o.FKBrandId);
            modelBuilder.Entity<Clothing>().HasOne(o => o.Image).WithMany(o => o.Clothing).HasForeignKey(o => o.FKImageId);

            modelBuilder.Entity<Clothing>().Property(o => o.Size).IsRequired(true);
            modelBuilder.Entity<Clothing>().Property(o => o.Color).IsRequired(true);

            modelBuilder.Entity<Costumer>().Property(o => o.PaymentMethod).IsRequired(true);

            modelBuilder.Entity<Order>().HasOne(o => o.Costumer).WithMany(o => o.Orders).HasForeignKey(o => o.FKCostumerId);

            modelBuilder.Entity<OrderLine>().HasOne(o => o.Clothing).WithMany(o => o.OrderLines).HasForeignKey(o => o.FKClothingId);
            modelBuilder.Entity<OrderLine>().HasOne(o => o.Order).WithMany(o => o.OrderLines).HasForeignKey(o => o.FKOrderId);




            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, Name = "Ralph Lauren" },
                new Brand { BrandId = 2, Name = "Tommy Hilfiger" },
                new Brand { BrandId = 3, Name = "Nike" },
                new Brand { BrandId = 4, Name = "Hugo Boss" },
                new Brand { BrandId = 5, Name = "Burberry" },
                new Brand { BrandId = 6, Name = "Levi Strauss & Co." },
                new Brand { BrandId = 7, Name = "Gucci" },
                new Brand { BrandId = 8, Name = "Lacoste" },
                new Brand { BrandId = 9, Name = "Adidas" },
                new Brand { BrandId = 10, Name = "Versace" });

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Accessories" },
                new Category { CategoryId = 2, Name = "Jackets" },
                new Category { CategoryId = 3, Name = "Trousers" },
                new Category { CategoryId = 4, Name = "Underwear" },
                new Category { CategoryId = 5, Name = "Suits" },
                new Category { CategoryId = 6, Name = "Skirts and dresses" },
                new Category { CategoryId = 7, Name = "Shoes" },
                new Category { CategoryId = 8, Name = "Sweaters and hoodies" },
                new Category { CategoryId = 9, Name = "T-Shirts" });

            modelBuilder.Entity<Image>().HasData(
                new Image { ImageId = 1, AltText = "Sort Ralph Lauren Polo", Url = "Images/SortRalphLaurenPolo.jpg" },
                new Image { ImageId = 2, AltText = "Grøn Ralph Lauren Polo", Url = "Images/GrønRalphLaurenPolo.jpg" },
                new Image { ImageId = 3, AltText = "Rød Ralph Lauren Polo", Url = "Images/RødRalphLaurenPolo.jpg" },
                new Image { ImageId = 4, AltText = "Blå Ralph Lauren Polo", Url = "Images/BlåRalphLaurenPolo.jpg" },
                new Image { ImageId = 5, AltText = "Gule Hugo Boss Underbukser", Url = "Images/GuleHugoBossUnderbukser.jpg" },
                new Image { ImageId = 6, AltText = "Hvide Hugo Boss Underbukser", Url = "Images/HvideHugoBossUnderbukser.jpg" },
                new Image { ImageId = 7, AltText = "Røde Hugo Boss Underbukser", Url = "Images/RødeHugoBossUnderbukser.jpg" },
                new Image { ImageId = 8, AltText = "Blå Hugo Boss Underbukser", Url = "Images/BlåHugoBossUnderbukser.jpg" },
                new Image { ImageId = 9, AltText = "Tommy Hilfinger Bukser", Url = "Images/GrønneTommyHilfingerBukser.jpg" });



            modelBuilder.Entity<Clothing>().HasData(
                new Clothing { ClothingId = 1, Title = "Sort Ralph Lauren Polo", Color = Colors.Black, FKBrandId = 1, FKCategoryId = 9, FKImageId = 1, Description = "Sort Ralph Lauren Polo", Price = 25, Size = Sizes.Medium },
                new Clothing { ClothingId = 2, Title = "Grøn Ralph Lauren Polo", Color = Colors.Green, FKBrandId = 1, FKCategoryId = 9, FKImageId = 2, Description = "Grøn Ralph Lauren Polo", Price = 25, Size = Sizes.Medium },
                new Clothing { ClothingId = 3, Title = "Rød Ralph Lauren Polo", Color = Colors.Red, FKBrandId = 1, FKCategoryId = 9, FKImageId = 3, Description = "Rød Ralph Lauren Polo", Price = 25, Size = Sizes.Medium },
                new Clothing { ClothingId = 4, Title = "Blå Ralph Lauren Polo", Color = Colors.Blue, FKBrandId = 1, FKCategoryId = 9, FKImageId = 4, Description = "Blå Ralph Lauren Polo", Price = 25, Size = Sizes.Medium },
                new Clothing { ClothingId = 5, Title = "Gule Hugo Boss Underbukser", Color = Colors.Yellow, FKBrandId = 4, FKCategoryId = 4, FKImageId = 5, Description = "Gule Hugo Boss Underbukser", Price = 5, Size = Sizes.Large },
                new Clothing { ClothingId = 6, Title = "Hvide Hugo Boss Underbukser", Color = Colors.White, FKBrandId = 4, FKCategoryId = 4, FKImageId = 6, Description = "Hvide Hugo Boss Underbukser", Price = 5, Size = Sizes.Large },
                new Clothing { ClothingId = 7, Title = "Røde Hugo Boss Underbukser", Color = Colors.Red, FKBrandId = 4, FKCategoryId = 4, FKImageId = 7, Description = "Røde Hugo Boss Underbukser", Price = 5, Size = Sizes.Large },
                new Clothing { ClothingId = 8, Title = "Blå Hugo Boss Underbukser", Color = Colors.Blue, FKBrandId = 4, FKCategoryId = 4, FKImageId = 8, Description = "Blå Hugo Boss Underbukser", Price = 5, Size = Sizes.Large },
                new Clothing { ClothingId = 9, Title = "Tommy Hilfinger Bukser", Color = Colors.Green, FKBrandId = 2, FKCategoryId = 3, FKImageId = 9, Description = "Grønne bukser", Price = 20, Size = Sizes.Small });


            base.OnModelCreating(modelBuilder);
        }

    }
}
