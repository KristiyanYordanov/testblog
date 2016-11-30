using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDemo.Services.Contracts
{
    public interface IMapper
    {
        T Map<T>(object objectToMap);
    }
}
