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
using ShowRegSys.ViewModels;

namespace ShowRegSys.Controllers
{
    [Authorize]
    public class RegController : Controller
    {
        private ShowContext db = new ShowContext();


        public ActionResult Index()
        {
            /*DogDropDownList();*/


            return View();
        }

        //GET
        public ActionResult Create()
        {
            EnrollmentCreateViewModel enrol = new EnrollmentCreateViewModel();

            var userIDb = WebSecurity.GetUserId(User.Identity.Name);
            var userIDa = Convert.ToInt32(userIDb);

            enrol.ShowList = db.Shows.ToList().Where(b => b.Date > DateTime.Now).Select(s => new SelectListItem { Text = s.Name, Value = s.ShowID.ToString() }).ToList();
            enrol.DogList = db.Dogs.ToList().Where(b => b.UserProfile.UserProfileId == userIDa).Select(d => new SelectListItem { Text = d.Name, Value = d.DogId.ToString() }).ToList();
            enrol.ClassList = db.Classes.ToList().Select(c => new SelectListItem { Text = c.NamePL, Value = c.ClassID.ToString() }).ToList();

            return View(enrol);

        }

        //POST:
        [HttpPost]
        public ActionResult Create(EnrollmentCreateViewModel enrol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var allElrollments = db.Enrollments;

                    foreach(var item in allElrollments)
                    {
                        if(item.DogID == enrol.SelectedDogFromList & item.ShowID == enrol.SelectedShowFromList)
                        {
                            return RedirectToAction("DogRegistred");
                        }
                    }


                    Enrollment newEnrol = new Enrollment()
                    {
                        ShowID = enrol.SelectedShowFromList,
                        DogID = enrol.SelectedDogFromList,
                        ClassID = enrol.SelectedClassFromList
                    };
                    db.Enrollments.Add(newEnrol);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                    
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unadle to save chandes.");
            }
            return View();
        }


        public ActionResult DogRegistred()
        {
            return View();
        }
    }
}