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
        [Display(Name = "Imię i przydomek")]
        public string Name { get; set; }

        [Display(Name="Numer PKR")]
        public string numerPKR { get; set; }
        
        public int PkrID { get; set; }

        [Required]
        [Display(Name = "Rasa")]
        public int BreedID { get; set; }

        [Display(Name = "Maść")]
        public int ColorID { get; set; }

        [Display(Name = "Rasa")]
        public int GenderID { get; set; }

        [Display(Name="Tatuaż lub chip")]
        public string TattooOrChip { get; set; }

        [Required]
        public int UserProfileId { get; set; }

        [Display(Name = "Hodowca")]
        public string Breeder { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Tytuły")]
        public string Titles { get; set; }

        public virtual Pkr Pkr { get; set; }
        public virtual Breed Breed { get; set; }
        public virtual Color Color { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}