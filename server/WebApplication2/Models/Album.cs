using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2
{
    public class Album
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string image { get; set; }
        public int year { get; set; }
        public ICollection<Song> songs { get; set; }
        public ICollection<Review> reviews { get; set; }
    }
}
