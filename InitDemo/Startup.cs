using AutoMapper;
using InitDemo.Models;
using InitDemo.Services;
using InitDemo.ViewModel;
using Microsoft.Owin;
using Ninject;
using Owin;
using System.Reflection;

[assembly: OwinStartupAttribute(typeof(InitDemo.Startup))]
namespace InitDemo
{
    public partial class Startup
    {
        private MapperConfiguration _mapperConfiguration { get; set; }

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);


            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });
        }

    }
}
