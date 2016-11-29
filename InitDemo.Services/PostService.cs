using InitDemo.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitDemo.Models;
using InitDemo.Data;

namespace InitDemo.Services
{
    public class PostService : BaseService<Post> ,IPostService
    {
        public PostService(IBlogSystemData data)
            :base(data)
        {
        }

        public override IQueryable<Post> GetAll()
        {
            return base.GetAll().OrderByDescending(p => p.DateCreated);
        }

        public override void Add(Post entity)
        {
            entity.DateCreated = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }
    }
}
