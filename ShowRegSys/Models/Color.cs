using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Color
    {
        public int ColorID { get; set; }
        public string NamePL { get; set; }
        public string NameEN { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }
    }
}