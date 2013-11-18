using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Gender
    {
        public int GenderID { get; set; }

        [Display(Name = "Płeć")]
        public string NamePL { get; set; }

        [Display(Name = "Gender")]
        public string NameEN { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}