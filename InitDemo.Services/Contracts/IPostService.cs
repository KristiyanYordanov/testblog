using InitDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDemo.Services.Contracts
{
    public interface IPostService : IService<Post>
    {
        IQueryable<Post> GetAll();
    }
}
