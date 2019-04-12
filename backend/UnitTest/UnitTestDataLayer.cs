using DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;
using UnitTest.Utilities.UnitTests.Utilities;
using System.Threading.Tasks;
using DataLayer.Entities.Enums;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTestDataLayer
    {
        public UnitTestDataLayer()
        {
            // ARRANGE
            using (var db = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        [TestMethod]
        public void GetClothing_Title_Brand_Category()
        {
            using (var db = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                // ACT
                List<Clothing> clothing = db.Clothing
                    .AsNoTracking()
                    .Include(o => o.Brand)
                    .Include(o => o.Category)
                    .ToList();

                // ASSERT
                Assert.AreEqual(clothing.Count > 0, true);
            }
        }
        [TestMethod]
        public void CreateClothing()
        {
            using (var db = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                // ARRANGE
                var clothingId = 0;
                Clothing clothing = new Clothing()
                {
                    Title = "New Clothing",
                    FKBrandId = 3,
                    Color = Colors.Black,
                    Price = 100,
                    Description = "Empty",
                    FKCategoryId = 2,
                    FKImageId = 6,
                    Size = Sizes.Large,
                };
                // ACT
                db.Clothing.Add(clothing);
                 db.SaveChanges();
                clothingId = clothing.ClothingId;

                // ASSERT
                clothing = db.Clothing
                    .Where(o => o.ClothingId == clothingId)
                    .First();


                Assert.AreNotEqual(clothing, null);
            }
        }


        [TestMethod]
        public void UpdateClothing_ClothingTitle_ClothingCategory()
        {
            using (var db = new ShopContext(SqlContext.TestDbContextOptions()))
            {
                // ARRANGE

                // ACT
                Clothing clothing = db.Clothing.First();
                clothing.Title = "UnitTest";
                clothing.FKBrandId = 3;
                db.SaveChanges();

                // ASSERT
                clothing = db.Clothing
                    .Include(o => o.Brand)
                    .AsNoTracking()
                    .First();


                Assert.AreEqual("UnitTest", clothing.Title);
                Assert.AreEqual("Nike", clothing.Brand.Name);
            }
        }
    }
}
