using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.Models;
using ShowRegSys.DAL;
using ShowRegSys.Filters;
using System.Web.Security;
using WebMatrix.WebData;
using ShowRegSys.ViewModels;

namespace ShowRegSys.Controllers
{  
    [Authorize]
    [InitializeSimpleMembership]
    public class ShowController : Controller
    {
        private ShowContext db = new ShowContext();
        private UsersContext dbUser = new UsersContext();

        //
        // GET: /Show/

        public ActionResult Index()
        {
            var shows = db.Shows.Include(o => o.Organizer).Include(r => r.Rank);

            return View(shows.ToList());
        }

        public ActionResult MyShows()
        {
            int userId = WebSecurity.GetUserId(User.Identity.Name);

            var getOrgId = (from u in dbUser.UserProfiles
                            where u.UserProfileId == userId
                            select u.OrganizerID).First();

            int getOrganizerId = Convert.ToInt16(getOrgId);

            var shows = db.Shows.Include(s => s.Organizer).Include(r => r.Rank).Where(d => d.Date >= DateTime.Now && d.OrganizerID == getOrganizerId);

            return View(shows.ToList());

        }

        //
        // GET: /Show/Details/5

        public ActionResult Details(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);
        }

        //
        // GET: /Show/Catalog/5
        public ActionResult Catalog(int id = 0)
        {
            
            //Show show = db.Shows.Find(id);
            //if (show == null)
            //{
           //     return HttpNotFound();
            //}
            var zgloszonePsy = from d in db.Dogs
                               join b in db.Breeds on d.BreedID equals b.BreedID
                               select new {DogID = d.DogId, DogName = d.Name, DogBirth = d.BirthDate, BreedName = b.Name };


            return View(zgloszonePsy);
        }

        //
        // GET: /Show/Create
        [Authorize(Roles = "Organizer")]
        public ActionResult Create()
        {
            int userId = WebSecurity.GetUserId(User.Identity.Name);

            int getOrgId = Convert.ToInt16((from u in dbUser.UserProfiles
                            where u.UserProfileId == userId
                            select u.OrganizerID).First());


            CreateEditShowViewModel show = new CreateEditShowViewModel();
            show.OrganizerID = getOrgId;
            show.RankList = db.Ranks.ToList().Select(r => new SelectListItem { Text = r.Name, Value = r.RankID.ToString() }).ToList();
            
            return View(show);
        }

        //
        // POST: /Show/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEditShowViewModel show)
        {
            if (ModelState.IsValid)
            {
                int userId = WebSecurity.GetUserId(User.Identity.Name);
                
                int getOrgId = Convert.ToInt16((from u in dbUser.UserProfiles
                            where u.UserProfileId == userId
                            select u.OrganizerID).First());

                Show newShow = new Show()
                {
                    Name = show.Name,
                    City = show.City,
                    Place = show.Place,
                    Date = show.Date,
                    RankID = show.SelectedRankFromList,
                    Attention = show.Attention,
                    EnrollmentDate = show.EnrollmentDate,
                    OrganizerID = getOrgId
                };
                show.RankList = db.Ranks.ToList().Select(r => new SelectListItem { Text = r.Name, Value = r.RankID.ToString() }).ToList();
                
                    db.Shows.Add(newShow);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Show/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return View("NoShow");
            }

            CreateEditShowViewModel editShow = new CreateEditShowViewModel()
            {
                ShowID = show.ShowID,
                Name = show.Name,
                City = show.City,
                Place = show.Place,
                Date = show.Date,
                SelectedRankFromList = show.RankID,
                Attention = show.Attention,
                EnrollmentDate = show.EnrollmentDate,
                OrganizerID = show.OrganizerID
            };
            editShow.RankList = db.Ranks.ToList().Select(r => new SelectListItem { Text = r.Name, Value = r.RankID.ToString() }).ToList();

            return View(editShow);
        }

        //
        // POST: /Show/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CreateEditShowViewModel editShow)
        {
            if (ModelState.IsValid)
            {
                Show show = db.Shows.Find(editShow.ShowID);
                
                show.Name = editShow.Name;
                show.City = editShow.City;
                show.Place = editShow.Place;
                show.Date = editShow.Date;
                show.RankID = editShow.SelectedRankFromList;
                show.Attention = editShow.Attention;
                show.EnrollmentDate = editShow.EnrollmentDate;
                show.OrganizerID = editShow.OrganizerID;
                

                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyShows");
            }

            editShow.RankList = db.Ranks.ToList().Select(r => new SelectListItem { Text = r.Name, Value = r.RankID.ToString() }).ToList();
            return View(editShow);
        }

        //
        // GET: /Show/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show ==     null)
            {   
                return HttpNotFound();
            }
            return View(show);
        }

        //
        // POST: /Show/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Show show = db.Shows.Find(id);
            db.Shows.Remove(show);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        //
        // GET: /Show/Reg/2

        public ActionResult Reg(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            return View(show);

        }

        private void OrganizerDropDownList(object selectedOrganizer = null)
        {
            var organizerQuery = from o in db.Organizers
                             orderby o.Name 
                             select o;

            ViewBag.OrganizerID = new SelectList(organizerQuery, "OrganizerID", "Name", selectedOrganizer);                       
        }

        private void RankDropDownList(object selectedRank = null)
        {
            var rankQuery = from r in db.Ranks
                            orderby r.Name
                            select r;
            ViewBag.RankID = new SelectList(rankQuery, "RankID", "Name", selectedRank);
        }
        
    }
}