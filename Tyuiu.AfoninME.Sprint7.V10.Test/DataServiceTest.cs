using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using Tyuiu.AfoninME.Sprint7.V10.Lib;

namespace Tyuiu.AfoninME.Sprint7.V10.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void LoadOrders_CheckCount()
        {
            var ds = new DataService();
            string path = Path.Combine(Path.GetTempPath(), "orders.csv");
            File.WriteAllText(path, "Иванов;Иван;Иваныч;123;Адрес;8911;ORD1;01.02.2025;Товар;100;2");
            var orders = ds.LoadOrders(path);
            Assert.AreEqual(1, orders.Count);
            Assert.AreEqual(200, orders[0].Total);
        }

        [TestMethod]
        public void Stats_Works()
        {
            var ds = new DataService();
            var list = new List<Order>
            {
                new Order { ProductPrice = 10, Quantity = 1 },
                new Order { ProductPrice = 5, Quantity = 2 }
            };
            var s = ds.GetStatistics(list);
            Assert.AreEqual(3, (int)s.Sum);
            Assert.AreEqual(2, s.Count); // всего 2 заказа
            Assert.AreEqual(20, (int)(s.Max));  // 10 и 10
        }
    }
}