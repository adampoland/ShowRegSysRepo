using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Class
    {
        public int ClassID { get; set; }

        [Display(Name = "Klasa")]
        public string NamePL { get; set; }

        [Display(Name = "Class")]
        public string NameEN { get; set; }

        public virtual ICollection<Enrollment> Endrollments { get; set; }
    }

}