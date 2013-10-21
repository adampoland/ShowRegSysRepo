using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShowRegSys.Models
{
    public class Organizer
    {
        public int OrganizerID { get; set; }
        public string  Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string BankAccount { get; set; }

        public virtual ICollection<Show> Shows { get; set; }
    }
}