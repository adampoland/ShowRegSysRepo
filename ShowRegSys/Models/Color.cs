using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Color
    {
        public int ColorID { get; set; }

        [Display(Name = "Maść")]
        public string NamePL { get; set; }

        [Display(Name = "Color")]
        public string NameEN { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}