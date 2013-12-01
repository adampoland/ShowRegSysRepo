using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using PagedList;
using ShowRegSys.Models;

namespace ShowRegSys.ViewModels
{
    public class ShowDetailsViewModel
    {
        public int? Page { get; set; }

        public int ShowId { get; set; }

        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Miejsce wystawy")]
        public string Place { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        public string RankName { get; set; }

        [Display(Name = "Uwagi")]
        public string Attention { get; set; }

        [Display(Name = "Data zgłoszeń")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Organizator")]
        public string OrganizerName { get; set; }

        [Display(Name = "Telefon")]
        public string OrganizerTel { get; set; }

        [Display(Name = "Email")]
        public string OrganizerEmail { get; set; }

        [Display(Name = "Konto bankowe")]
        public string OrganizerBankAccount { get; set; }

        [Display(Name = "Adress WWW")]
        public string OrganizerWww { get; set; }

        public IPagedList<Enrollment> EnrollmentList { get; set; }
    }
}