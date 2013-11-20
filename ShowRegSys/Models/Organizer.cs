using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShowRegSys.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }

        [Display(Name = "Orgnizator")]
        public string  Name { get; set; }

        [Display(Name = "Miasto")]
        public string City { get; set; }

        [Display(Name = "Ulica")]
        public string Address { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }   

        [Display(Name = "Telefon")]
        public string Telephone { get; set; }

        [Display(Name = "Konto bankowe")]
        public string BankAccount { get; set; }

        [Display(Name = "Adres WWW")]
        public string WebAdress { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
        public virtual ICollection<UserProfile> userProfile { get; set; }
    }
}