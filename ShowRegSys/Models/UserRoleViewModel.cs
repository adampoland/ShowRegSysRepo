using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShowRegSys.Models
{
    public class UserRoleViewModel
    {
        public UserRoleViewModel()
        {
            Roles = new List<RoleViewModel>();
        }
        public string UserId { get; set; }
        public List<RoleViewModel> Roles { get; set; }
    }

    public class RoleViewModel
    {
        public bool IsInRole { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int RoleId { get; set; }
        [HiddenInput(DisplayValue = true)]
        public string RoleName { get; set; }
    }
}