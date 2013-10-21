using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}