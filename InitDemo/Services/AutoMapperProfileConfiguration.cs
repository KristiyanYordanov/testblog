using AutoMapper;
using InitDemo.Models;
using InitDemo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InitDemo.Services
{
    public class AutoMapperProfileConfiguration : Profile
    {
        protected override void Configure()
        {
            CreateMap<Post, PostVM>();


        }
    }
    
}