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
        [Required]
        [StringLength(100, ErrorMessage = "error" ,MinimumLength =2)]
        public string Name { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        [Required]
        public String Content { get; set; }
    }
}