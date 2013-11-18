using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Rank
    {
        public int RankID { get; set; }

        [Display(Name = "Ranga")]
        public string Name { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}