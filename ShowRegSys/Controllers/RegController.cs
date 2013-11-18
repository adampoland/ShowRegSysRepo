using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.Models;
using ShowRegSys.DAL;
using System.Security;
using WebMatrix.WebData;
using System.Web.Security;
using ShowRegSys.Filters;

namespace ShowRegSys.Controllers
{
    [Authorize]
    public class RegController : Controller
    {
        private ShowContext db = new ShowContext();


        public ActionResult Index()
        {
            DogDropDownList();
            return View();
        }

        //GET
        public ActionResult Create()
        {
            DogDropDownList();
            ShowDropDownList();

            return View();

        }

        //POST:
        [HttpPost]
        public ActionResult Create([Bind(Include = "ShowID, DogId")] Enrollment enrollment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Enrollments.Add(enrollment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unadle to save chandes.");
            }
            ShowDropDownList(enrollment.ShowID);
            DogDropDownList(enrollment.DogID);
            return View(enrollment);
        }
        
        private void DogDropDownList(object selectedDog = null)
        {
            var userIDb = WebSecurity.GetUserId(User.Identity.Name);
            var userIDa = Convert.ToInt32(userIDb);
            var dogQuery = from d in db.Dogs
                           where d.UserProfile.UserProfileId == userIDa
                           orderby d.Name
                           select d;
            ViewBag.DogID = new SelectList(dogQuery, "DogID", "Name", selectedDog);
        }

        private void ShowDropDownList(object selectedShow = null)
        {
            var showQuery = from s in db.Shows
                            where s.Date > DateTime.Now
                            orderby s.Name
                            select s;
            ViewBag.ShowID = new SelectList(showQuery, "ShowID", "Name", selectedShow);
        }
    }
}