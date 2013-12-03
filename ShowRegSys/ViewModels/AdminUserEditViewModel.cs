using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.Security;

namespace ShowRegSys.ViewModels
{
    public class AdminUserEditViewModel
    {
        public MembershipUserCollection Users { get; set; }
        public string[] Roles { get; set; }

        /*
        [Display(Name = "ID użytkownika")]
        public int UserId { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        public string UserEmail { get; set; }

        [Display(Name= "Role")]
        public List<SelectListItem> RoleList { get; set; }
        public int SelectedRoleFromList { get; set; }
         * */

    }
}
