using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PagedList;
using ShowRegSys.Models;

namespace ShowRegSys.ViewModels
{
    public class DogDetailsViewModel
    {
        public int? Page { get; set; }

        [Display(Name = "Imię i przydomek")]
        public string Name { get; set; }

        [Display(Name = "Numer PKR")]
        public string numerPKR { get; set; }

        public string PkrName { get; set; }

        [Display(Name = "Rasa")]
        public string BreedName { get; set; }

        [Display(Name = "Maść")]
        public string  ColorName { get; set; }

        [Display(Name = "Płeć")]
        public string GenderName { get; set; }

        [Display(Name = "Tatuaż lub chip")]
        public string TattooOrChip { get; set; }


        [Display(Name = "Hodowca")]
        public string Breeder { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Tytuły")]
        public string Titles { get; set; }

        public IPagedList<Enrollment> EnrollmentPagedList { get; set; }


    }
}