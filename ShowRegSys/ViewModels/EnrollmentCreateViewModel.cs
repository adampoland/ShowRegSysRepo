using System;
using System.Collections.Generic;
using System.Linq;
using ShowRegSys.Models;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShowRegSys.ViewModels
{
    public class EnrollmentCreateViewModel
    {

        [Display(Name = "Wybierz wystawę")]
        public List<SelectListItem> ShowList { get; set; }
        public int SelectedShowFromList { get; set; }

        [Display(Name = "Wybierz psa")]
        public List<SelectListItem> DogList { get; set; }
        public int SelectedDogFromList { get; set; }

        [Display(Name = "Wybierz Klase")]
        public List<SelectListItem> ClassList { get; set; }
        public int SelectedClassFromList { get; set; }


    }
}