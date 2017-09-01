using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;

namespace EssentialTools.Controllers
{
    public class HomeController : Controller
    {
        private IValueCalculator calc;
        private Product[] products =
        {
            new Product {Name="Kayak",Category="Watersports",Price=275m},
            new Product {Name="Lifejacket",Category="watersports",Price=48.95m},
            new Product {Name="Soccer ball",Category="Soccer",Price=19.5m},
            new Product {Name="Corner flag",Category="Soccer",Price=34.95m}
        };
        public HomeController(IValueCalculator calcParam)
        {
            calc = calcParam;
        }
        public ActionResult Index()
        {
            ShoppingCart cart = new ShoppingCart(calc)
            {
                Products = products
            };
            decimal totalValue = cart.CalculateProductTotal();
            return View(totalValue);
        }
        // GET: Home
        //public ActionResult Index()
        //{ //5章到6章
        //    //LinqValueCalculator calc = new LinqValueCalculator();
        //    IValueCalculator calc = new LinqValueCalculator() ;
        //    //ShoppingCart cart = new ShoppingCart(calc)
        //    //{
        //    //    Products = products
        //    //};
        //    ShoppingCart cart = new ShoppingCart(calc);
        //    cart.Products = products;
        //    decimal totalValue = cart.CalculateProductTotal();
        //    return View(totalValue);
        //}
        //107页，6.2.3 Ninject初步
        //public ActionResult Index()
        //{
        //    IKernel ninjectKernel = new StandardKernel();
        //    //创建一个Ninject内核
        //    /*
        //         第一个阶段是准备使用Ninject，创建一个Ninject的Kernel（内核）实例，它是一个内核对象，
        //         负责解析依赖项并创建新的对象（比如用内核创建一个IValueCalculator 对象，而不再使用new关键字）。
        //        第一阶段的代码为：
        //        IKernel ninjectKernel = new StandardKernel(); 
        //        StandardKernel类是Ninject.IKernel 接口的标准实现类（标准内核），它足以完成我们想要的任何功能要求。
        //    */

        //    ninjectKernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        //    //配置Ninject，使其理解笔者用到的每一个接口所希望使用的实现对象
        //    //将想要使用的接口设置为bind方法的类型参数，并在其返回的结果上调用To方法，
        //    //将希望实例化的实现类设置为To方法的类型参数,
        //    //该语句告诉Ninject，IValueCalculator接口的依赖项应该通过创建LinqValueCalculator类的实例来进行解析
        //    /*
        //         第二阶段则是配置内核，即指定某一个接口是由那个类实现的，代码如下：
        //         ninjectKernel.Bind().To(); 它说明IValueCalculator接口的依赖项解析应该
        //         通过创建LinqValueCalculator类的实例来进行。
        //     */

        //    IValueCalculator calc = ninjectKernel.Get<IValueCalculator>();
        //    //使用Ninject来创建一个对象，其做法是调用内核的Get方法,
        //    //Get方法告诉Ninject笔者感兴趣的是哪一个接口，而该方法的结果是刚才用To方法指定的实现类型的一个实例
        //    /*
        //         第三阶段就是使用Ninject（或者说使用内核）创建（IValueCalculator）对象了。
        //         其代码如下：
        //         IValueCalculator calc = ninjectKernel.Get();
        //         这里已经取得可一些进展，但它依旧没有解决Home控制器和LinqValueCalculator的紧耦合问题，
        //         那需要做的就是下一步，依赖项注入了。
        //     */
        //    ShoppingCart cart = new ShoppingCart(calc)
        //    {
        //        Products = products
        //    };
        //    decimal totalValue = cart.CalculateProductTotal();
        //    return View(totalValue);
        //}
        //public ActionResult Action()
        //{
        //    Shopping sp = new Shopping();
        //    return View(sp.CalcPrice(products));
        //}
    }
}