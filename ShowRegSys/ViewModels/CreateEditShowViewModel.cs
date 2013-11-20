using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShowRegSys.ViewModels
{
    public class CreateEditShowViewModel
    {
        public int ShowID { get; set; }
        
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

        public List<SelectListItem> RankList { get; set; }
        public int SelectedRankFromList { get; set; }

        [Display(Name = "Uwagi")]
        public string Attention { get; set; }

        [Display(Name = "Data zgłoszeń")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public int OrganizerID { get; set; }

    }
}