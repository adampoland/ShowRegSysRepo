using System; 
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.Models;
using ShowRegSys.DAL;
using PagedList;
using System.Security;
using WebMatrix.WebData;
using System.Web.Security;
using ShowRegSys.Filters;


namespace ShowRegSys.Controllers
{
    [InitializeSimpleMembership] 
    public class DogController : Controller
    {
        private ShowContext db = new ShowContext();

        //
        // GET: /Dog/
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm 
                = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var dogs = db.Dogs.Include(d => d.Breed).Include(d => d.User);

            if (!String.IsNullOrEmpty(searchString))
            {
                dogs = dogs.Where(d => d.Name.ToUpper().Contains(searchString.ToUpper())
                    || d.Breed.Name.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "Name_desc":
                    dogs = dogs.OrderByDescending(d => d.Name);
                    break;
                default:
                    dogs = dogs.OrderBy(d => d.Name);
                    break;
            }
            
            int pageSize = 5;
            int pageNumber = ( page ?? 1);

            return View(dogs.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /Dog/Details/5

        public ActionResult Details(int id = 0)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        //
        // GET: /Dog/Create

        public ActionResult Create()
        {

            var userID = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Name");
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "NameEN");
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "NameEN");
            ViewBag.UserID = userID;
            return View();
        }

        //
        // POST: /Dog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Dogs.Add(dog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            var userID = (Guid)Membership.GetUser(User.Identity.Name).ProviderUserKey;
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Name", dog.BreedID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "NameEN");
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "NameEN");
            ViewBag.UserID = Convert.ToInt32(userID);
            return View(dog);
        }

        //
        // GET: /Dog/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Name", dog.BreedID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", dog.UserID);
            return View(dog);
        }

        //
        // POST: /Dog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dog dog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Name", dog.BreedID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "Name", dog.UserID);
            return View(dog);
        }

        //
        // GET: /Dog/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Dog dog = db.Dogs.Find(id);
            if (dog == null)
            {
                return HttpNotFound();
            }
            return View(dog);
        }

        //
        // POST: /Dog/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dog dog = db.Dogs.Find(id);
            db.Dogs.Remove(dog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Moje(int? userID)
        {
            var userIDb = WebSecurity.GetUserId(User.Identity.Name);
            var userIDa = Convert.ToInt32(userIDb);
            userID = userIDa;
            var dogs = from d in db.Dogs
                       where d.User.UserID == userIDa
                       orderby d.Name
                       select d;

            return View(dogs.ToList());
                       
        }

        public ActionResult Moja()
        {
            var dogs = db.Dogs;
            return View(dogs.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}