using System;
using System.Collections.Generic;
using ShowRegSys.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.ViewModels
{
    public class DogCreateViewModel
    {
        public int DogId { get; set; }

        [Display(Name = "Imie i przydomek")]
        public string Name { get; set; }

        [Display( Name = "Numer PKR")]
        public string PkrNumber { get; set; }

        [Display(Name = "Rasa")]
        public List<SelectListItem> BreedList { get; set; }
        public int SelectedBreedFromList { get; set; }

        [Display(Name = "Kolor")]
        public List<SelectListItem> ColorList { get; set; }
        public int SelectedColorFromList { get; set; }

        [Display(Name = "Płeć")]
        public List<SelectListItem> GenderList { get; set; }
        public int SelectedGenderFromList { get; set; } 

        [Display(Name = "Numer tatuażu lub chipa")]
        public string TattooOrChip { get; set; }

        public int UserProfileId { get; set; }

        [Display(Name = "Hodowca")]
        public string Breeder { get; set; }

        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Tytuły")]
        public string Titles { get; set; }

        [Display(Name = "Numer PKR")]
        public List<SelectListItem> PkrList { get; set; }
        public string SelectedPkrValue { get; set; }
    }
}