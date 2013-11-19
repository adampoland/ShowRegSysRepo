using System;
using System.Collections.Generic;
using ShowRegSys.Models;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.ViewModels
{
    public class CreateDogViewModel
    {
        public int DogId { get; set; }

        public string Name { get; set; }

        public string numerPKR { get; set; }

        public List<SelectListItem> BreedList { get; set; }

        public int SelectedBreedFromList { get; set; }

        public List<SelectListItem> ListaColor { get; set; }

        public int SelectedColorFromList { get; set; }

        public List<SelectListItem> ListaGender { get; set; }

        public int SelectedGenderFromList { get; set; } 

        public string TattooOrChip { get; set; }

        public int UserProfileId { get; set; }

        public string Breeder { get; set; }

        public DateTime BirthDate { get; set; }

        public string Titles { get; set; }

        public List<SelectListItem> ListaPkr { get; set; }

        public string SelectedPkrValue { get; set; }
    }
}