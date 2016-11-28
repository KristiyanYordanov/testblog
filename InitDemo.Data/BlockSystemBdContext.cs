using InitDemo.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDemo.Data
{
    public class BlockSystemBdContext: IdentityDbContext<ApplicationUser>
    {
        public BlockSystemBdContext() :base("name=BlogEntities")
        {
                
        }
        public virtual DbSet<Post> Post { get; set; }
     

        public static BlockSystemBdContext Create()
        {
            return new BlockSystemBdContext();
        }
        
    }
}
