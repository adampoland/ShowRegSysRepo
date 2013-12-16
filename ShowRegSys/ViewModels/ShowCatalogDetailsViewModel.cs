using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.Models;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.ViewModels
{
    public class ShowCatalogDetailsViewModel
    {
        public int ShowId { get; set; }

        [Display(Name = "Nazwa wystawy")]
        public string ShowName { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Miejsce wystawy")]
        public string Place { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Ranga")]
        public string Rank { get; set; }

        [Display(Name = "Organizator")]
        public string OrganizerName { get; set; }

        [Display(Name = "Telefon")]
        public string Telephone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Konto bankowe")]
        public string BankAccount { get; set; }

        [Display(Name = "Adres WWW")]
        public string WebAddress { get; set; }

        [Display(Name = "Uwagi")]
        public string Attention { get; set; }

        [Display(Name = "Liczba zgłoszonych psów")]
        public int DogCount { get; set; }



        public List<Enrollment> EnrolList { get; set; }
    }
}