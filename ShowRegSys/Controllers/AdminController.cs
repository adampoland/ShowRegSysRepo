using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.ViewModels;
using System.Web.Security;
using WebMatrix.WebData;
using ShowRegSys.Models;
using ShowRegSys.DAL;
using System.Web.ApplicationServices;

namespace ShowRegSys.Controllers
{
    public class AdminController : Controller
    {
        private ShowContext db = new ShowContext();
        private UsersContext dbUser = new UsersContext();
        
        
        //
        // GET: /Admin/
        public ActionResult Index()
        {
            var users = dbUser.UserProfiles.ToList();

            return View(users);
        }

        public ActionResult Edit()
        {
            int userId = WebSecurity.GetUserId(User.Identity.Name);
            var user = dbUser.UserProfiles.Find(userId);
            ViewBag.RolesForThisUser = Roles.GetRolesForUser(user.UserName);

            return View(user);

        }
        

        //
        // Create a new role to the user
        [Authorize(Roles = "Admin")]
        public ActionResult RoleAddToUser()
        {
            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;

            return View();
        }

        //
        // Add role to the user
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RoleAddToUser(string RoleName, string UserName)
        {

            if (Roles.IsUserInRole(UserName, RoleName))
            {
                ViewBag.ResultMessage = "This user already has the role specified !";
            }
            else
            {
                Roles.AddUserToRole(UserName, RoleName);
                ViewBag.ResultMessage = "Username added to the role succesfully !";
            }

            SelectList list = new SelectList(Roles.GetAllRoles());
            ViewBag.Roles = list;
            return View();
        }

        //
        /// Get all the roles for a particular user
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetRoles(string UserName)
        {   
 //           if (!string.IsNullOrWhiteSpace(UserName))
     //       {
                ViewBag.RolesForThisUser = Roles.GetRolesForUser(UserName);
                SelectList list = new SelectList(Roles.GetAllRoles());
                ViewBag.Roles = list;
         //   }
            return View("RoleAddToUser");
        }


    }
}
