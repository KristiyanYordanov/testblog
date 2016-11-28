using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDemo.Models
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public String Content { get; set; }


        //one to many relation
       public virtual ApplicationUser Author { get; set; }
      
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
