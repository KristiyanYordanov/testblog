[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(InitDemo.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(InitDemo.App_Start.NinjectWebCommon), "Stop")]

namespace InitDemo.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Services.Contracts;
    using Services;
    using Data;
    using AutoMapper;
    using Models;
    using ViewModel;
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
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IUsersService>().To<UsersService>();
            kernel.Bind<IBlogSystemData>().To<BlogSystemData>();

            var config = new MapperConfiguration(
     c => {
        // foreach (var profile in profiles)
        // {
        //     c.AddProfile(profile);
        // }
        c.CreateMap<Post, PostVM>();
     });
            // Solution starts here
            var mapper = config.CreateMapper();
            kernel.Bind<IMapper>().ToConstant(mapper);
        }        
    }
}
