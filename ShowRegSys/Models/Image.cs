using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int ShowId { get; set; }

        [Display ( Name = "Nazwa")]
        public string Name { get; set; }

        [Display (Name = "Ścieżka")]
        public string Path { get; set; }

        public virtual Show Shows { get; set; }
    }
}