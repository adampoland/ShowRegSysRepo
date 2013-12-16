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
using PagedList;

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

        public ActionResult Details(ShowDetailsViewModel showDetails, int? page, string sortOrder, string currentFilter, string searchString, int id = 0)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm
                = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";

            if (searchString != null)
            {
                showDetails.Page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }

            var enrol = db.Enrollments.Where(e => e.ShowID == show.ShowID);


            if (!String.IsNullOrEmpty(searchString))
            {
                enrol = enrol.Where(e => e.Dogs.Breed.Name.ToUpper().Contains(searchString.ToUpper()));
                    
            }

            switch (sortOrder)
            {
                case "Name_desc":
                    enrol = enrol.OrderByDescending(e => e.Classes.NamePL);
                    break;
                default:
                    enrol = enrol.OrderBy(e => e.Classes.NamePL);
                    break;
            }

            var pageIndex = showDetails.Page ?? 1;
            int pageSize = 10;

            showDetails.ShowId = show.ShowID;
            showDetails.Name = show.Name;
            showDetails.City = show.City;
            showDetails.Place = show.Place;
            showDetails.Date = show.Date;
            showDetails.RankName = show.Rank.Name;
            showDetails.Attention = show.Attention;
            showDetails.EnrollmentDate = show.EnrollmentDate;
            showDetails.OrganizerName = show.Organizer.Name;
            showDetails.OrganizerTel = show.Organizer.Telephone;
            showDetails.OrganizerEmail = show.Organizer.Email;
            showDetails.OrganizerBankAccount = show.Organizer.BankAccount;
            showDetails.OrganizerWww = show.Organizer.WebAdress;
            showDetails.EnrollmentList = enrol.ToPagedList(pageIndex, pageSize);

            return View(showDetails);
        }

        //
        // GET: /Show/Catalog/5
        public ActionResult Catalog(int id = 0)
        {

            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }

            var enrol = db.Enrollments.Where(e => e.ShowID == show.ShowID);
            int orgID = show.OrganizerID;
            Organizer organizer = db.Organizers.Find(orgID);

            ShowCatalogDetailsViewModel enrolments = new ShowCatalogDetailsViewModel();
            enrolments.ShowId = show.ShowID;
            enrolments.ShowName = show.Name;
            enrolments.City = show.City;
            enrolments.Place = show.Place;
            enrolments.Date = show.Date;
            enrolments.Rank = show.Rank.Name;
            enrolments.OrganizerName = organizer.Name;
            enrolments.Telephone = organizer.Telephone;
            enrolments.Email = organizer.Email;
            enrolments.BankAccount = organizer.BankAccount;
            enrolments.WebAddress = organizer.WebAdress;
            enrolments.Attention = show.Attention;
            enrolments.EnrolList = db.Enrollments.Where(e => e.ShowID == show.ShowID).OrderBy(e => e.Dogs.PkrID).ThenBy(e => e.Dogs.Breed.Name).ThenBy(e => e.Classes.ClassID).ToList();



            return View(enrolments);
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


            ShowCreateEditViewModel show = new ShowCreateEditViewModel();
            show.OrganizerID = getOrgId;
            show.RankList = db.Ranks.ToList().Select(r => new SelectListItem { Text = r.Name, Value = r.RankID.ToString() }).ToList();
            
            return View(show);
        }

        //
        // POST: /Show/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowCreateEditViewModel show)
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

            ShowCreateEditViewModel editShow = new ShowCreateEditViewModel()
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
        public ActionResult Edit(ShowCreateEditViewModel editShow)
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
            if (show == null)
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
            var enrol = db.Enrollments.Where(e => e.ShowID == show.ShowID).ToList();
            foreach(var item in enrol)
            {
                db.Enrollments.Remove(item);
                db.SaveChanges();
            }

            var images = db.Images.Where(i => i.ShowId == show.ShowID).ToList();
            foreach(var item in images)
            {
                db.Images.Remove(item);
                db.SaveChanges();
            }

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