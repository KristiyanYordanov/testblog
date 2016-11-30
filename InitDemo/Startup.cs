using AutoMapper;
using InitDemo.Models;
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
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

    }
}
