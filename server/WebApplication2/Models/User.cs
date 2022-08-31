using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool isAdmin { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
        public int personId { get; set; }
        public virtual Person person { get; set; }
    }
}
