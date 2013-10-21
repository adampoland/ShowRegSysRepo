using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Breed
    {
        public int BreedID { get; set; }
        public string Name { get; set; }
        public int Group { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}