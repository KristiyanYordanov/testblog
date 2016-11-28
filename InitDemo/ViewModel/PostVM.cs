using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InitDemo.ViewModel
{
    public class PostVM
    {
        
        public int Id { get; set; }
        [StringLength(100, ErrorMessage = "error" ,MinimumLength =2)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public String Content { get; set; }
    }
}