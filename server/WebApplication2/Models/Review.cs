using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Review
    {
        [Key]
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int rating { get; set; }
        public int album_id { get; set; }
        public virtual Album album { get; set; }
        public int user_id { get; set; }
        public virtual User user { get; set; }
    }
}
