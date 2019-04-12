using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanConnectToDatabase()
        {
            //bool canConnect = false;
            //using (ShopContext shopContext = new ShopContext())
            //{
            //    canConnect = shopContext.Database.CanConnect();
            //}

            //Assert.AreEqual(true, canConnect);
        }

    }
}
