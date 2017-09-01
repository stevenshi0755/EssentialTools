[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EssentialTools.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EssentialTools.App_Start.NinjectWebCommon), "Stop")]

namespace EssentialTools.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new EssentialTools.Infrastructure.NinjectDependencyResolver(kernel));
        }
        /*
         创建完依赖项解析器后还是无法实现功能，
            因为我们还没有告诉MVC去使用它，那此时该做的事情就是注册该解析器让MVC去使用它。
            当我们引入Ninject时它会在App_Start文件夹中创建一个NinjectWebCommon.cs文件，
            它定义了应用程序启动时会自动调用的一些方法。在NinjectWebCommon类中的RegisterServices方法中
            我们填写一条语句来创建一个依赖项解析器NinjectDependencyResolver 的实例，
            并用 System.Web.Mvc.DependencyResolver类定义的SetResolver静态方法将其注册为MVC框架的解析器
         直到此时我们已经做得工作有：创建依赖项解析器，并在其中将LinqValueCalculator绑定为
            IValueCalculator接口的实现类，并且告诉MVC使用我们的依赖项解析器。
            准备工作已经准备就绪了，看看我们怎样使用费了这么大劲终于完成的依赖项注入吧
         
         */
    }
}
