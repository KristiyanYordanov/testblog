using AutoMapper;
using InitDemo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDemo.Services
{
    public  class AutoMapperAdapter : Contracts.IMapper
    {
     

        public T Map<T>(object objectToMap)
        {
            //Mapper.Map is a static method of the library!
            return Mapper.Map<T>(objectToMap);
        }
    }
}
