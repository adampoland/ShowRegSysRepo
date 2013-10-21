using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Rank
    {
        public int RankID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}