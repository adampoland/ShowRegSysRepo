using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Breed
    {
        public int BreedID { get; set; }

        [Display(Name = "Rasa")]
        public string Name { get; set; }
        public int PkrID { get; set; }

        //public virtual ICollection<Dog> Dogs { get; set; }
        public virtual Pkr Pkr { get; set; }
    }
}