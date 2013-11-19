using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Pkr
    {
        public int PkrID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
        public virtual ICollection<Breed> Breeds { get; set; }
    }
}