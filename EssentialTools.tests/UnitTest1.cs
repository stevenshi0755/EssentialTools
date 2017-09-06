using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EssentialTools.Models;

namespace EssentialTools.tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDiscountHelper getTestObject()
        {
            return new MinimumDiscountHelper();
        }
        [TestMethod]
        public void Discount_Above_100()
        {
            //准备
            IDiscountHelper target = getTestObject();
            decimal total = 200;
            //动作
            var discountedTotal = target.ApplyDiscount(total);
            //断言
            Assert.AreEqual(total * 0.9m, discountedTotal);
        }
    }
}
