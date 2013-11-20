using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.ViewModels
{
    public class EditUserViewModel
    {

        public int UserProfileId { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string PostCode { get; set; }

        [Display(Name = "Numer telefony")]
        public string Telephone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public int? OrganizerID { get; set; }
    }
}