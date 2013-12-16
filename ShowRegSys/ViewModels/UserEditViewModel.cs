using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.ViewModels
{
    public class UserEditViewModel
    {

        public int UserProfileId { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Kod pocztowy")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{2}[0-9]$",
            ErrorMessage = "Błędny kod pocztowy")]
        public string PostCode { get; set; }

        [Display(Name = "Numer telefony")]
        public string Telephone { get; set; }

        [Display(Name = "Email")]
        [RegularExpression(@"^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})$", ErrorMessage = "Błedny adres email.")]
        [Required]
        public string Email { get; set; }

        public int? OrganizerID { get; set; }
    }
}