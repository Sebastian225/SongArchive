using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2
{
    public class Song
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public int album_id { get; set; }
        public Album album { get; set; }
    }
}
