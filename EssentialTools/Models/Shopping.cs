using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EssentialTools.Models
{
    public class Shopping
    {
        //计算price之和
        public decimal CalcPrice(IEnumerable<Product> shops)
        {
            return shops.Sum(p => p.Price);
        }

    }
}