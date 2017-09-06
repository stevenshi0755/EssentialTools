using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class LinqValueCalculator:IValueCalculator
    {
        //public decimal ValueProducts(IEnumerable<Product> products)
        //{
        //    return products.Sum(p => p.Price);
        //}
        //public decimal ValueProducts(IEnumerable<Product> products)
        //{
        //    return products.Sum(p => p.Price);
        //}
        //private IDiscountHelper discounter;
        //public LinqValueCalculator(IDiscountHelper discountParam)
        //{
        //    discounter = discountParam;
        //}
        //public decimal ValueProducts(IEnumerable<Product> products)
        //{
        //    return discounter.ApplyDiscount(products.Sum(p => p.Price));
        //}
        //115 6.2.8
        private IDiscountHelper discounter;
        private static int counter = 0;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            discounter = discountParam;
            System.Diagnostics.Debug.WriteLine(string.Format("Instance{0} created", ++counter));
        }
        public decimal ValueProducts(IEnumerable<Product> products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        }
    }
}