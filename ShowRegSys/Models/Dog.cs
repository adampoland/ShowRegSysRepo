using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Dog
    {
        public int DogId { get; set; }

        [Required]
        [StringLength(100, MinimumLength=1)]
        public string Name { get; set; }

        public string PKR { get; set; }

        [Required]
        public int BreedID { get; set; }

        public int ColorID { get; set; }

        public int GenderID { get; set; }

        [Display(Name="Tatoo or Chip")]
        public string TattooOrChip { get; set; }

        [Required]
        public int UserID { get; set; }

        public string Breeder { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Titles { get; set; }


        public virtual Breed Breed { get; set; }
        public virtual Color Color { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}