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

namespace ShowRegSys.Controllers
{  
    [Authorize]
    [InitializeSimpleMembership]
    public class ShowController : Controller
    {
        private ShowContext db = new ShowContext();

        //
        // GET: /Show/

        public ActionResult Index()
        {
            var shows = db.Shows.Include(s => s.Organizer).Include(r => r.Rank).Where(d => d.Date >= DateTime.Now);
                
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
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            RankDropDownList();
            OrganizerDropDownList();
            return View();
        }

        //
        // POST: /Show/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShowID, Name, Date, RankID, OrganizerID")] Show show)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Shows.Add(show);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unadle to save chandes.");
            }
            RankDropDownList(show.RankID);
            OrganizerDropDownList(show.OrganizerID);
            return View(show);
        }

        //
        // GET: /Show/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Show show = db.Shows.Find(id);
            if (show == null)
            {
                return HttpNotFound();
            }
            RankDropDownList(show.RankID);
            OrganizerDropDownList(show.OrganizerID);
            return View(show);
        }

        //
        // POST: /Show/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Show show)
        {
            if (ModelState.IsValid)
            {
                db.Entry(show).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(show);
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