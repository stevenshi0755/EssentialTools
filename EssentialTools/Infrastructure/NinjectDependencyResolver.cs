using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EssentialTools.Models;
using Ninject;
using Ninject.Web.Common;


namespace EssentialTools.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kenelParam)
        {
            kernel = kenelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
        }
    }
    /*
     依赖项注入实现的功能就是，将上问Home控制器中的 内核创建、配置和
        创建对象拿出来放到一个专门的类中，并保证在应用程序运行时依赖项得到解析。
     创建依赖项解析器
        NinjectDependencyResolver 类实现了System.Web.Mvc命名空间中的IDependencyResolver接口，
        MVC框架用它来获取所需的对象。 MVC框架在需要类实例以便对一个传入请求进行服务时，
        会调用GetService和GetServices方法。依赖性解析器器要做的工作就是创建这一实例。 
        上述依赖性解析器也是建立Ninject绑定（自定义接口和实现类的绑定）的地方，
        在AddBindings方法中便实现了IValueCalculator接口和LinqValueCalculator实现类之间关系的配置。
     */

}