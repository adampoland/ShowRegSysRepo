using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        [Required]
        public int ShowID { get; set; }

        [Required]
        public int DogID { get; set; }

        public virtual Show Shows { get; set; }
        public virtual Dog Dogs { get; set; }
    }
}