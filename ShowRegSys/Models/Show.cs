using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Show
    {
        public int ShowID { get; set; }

        [Required]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Miejsce wystawy")]
        public string Place { get; set; }
        
        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        public int RankID { get; set; }

        [Required]
        [Display(Name = "Uwagi")]
        public string Attention { get; set; }

        [Required]
        [Display(Name = "Data zgłoszeń")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [Required]
        public int OrganizerID { get; set; }

        public virtual Rank Rank { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}