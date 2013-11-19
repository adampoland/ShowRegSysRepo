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
using ShowRegSys.ViewModels;
using System.Web.Script.Serialization;


namespace ShowRegSys.Controllers
{
    [Authorize]
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

            var dogs = db.Dogs.Include(d => d.Breed).Include(d => d.UserProfile);

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

            int zlicz = dogs.ToList().Count();

            if (zlicz > 0)
            {
                return View(dogs.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("NoDog");
            }
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

        public ActionResult Create(int pkrID = 0)
        {
            CreateDogViewModel dog = new CreateDogViewModel();
            dog.UserProfileId = WebSecurity.GetUserId(User.Identity.Name);
            dog.ListaGender = db.Genders.ToList().Select(u => new SelectListItem { Text = u.NameEN, Value = u.GenderID.ToString() }).ToList();
            dog.ListaColor = db.Colors.ToList().Select(u => new SelectListItem { Text = u.NameEN, Value = u.ColorID.ToString() }).ToList();
            dog.ListaPkr = db.Pkrs.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.Name }).ToList();
            dog.BreedList = db.Breeds.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.BreedID.ToString() }).ToList();
            return View(dog);
        }

        //
        // POST: /Dog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateDogViewModel dog)
        {
            if (ModelState.IsValid)
            {
                Dog newDog = new Dog()
                {
                    BirthDate = dog.BirthDate,
                    GenderID = dog.SelectedGenderFromList,
                    BreedID = dog.SelectedBreedFromList,
                    ColorID = dog.SelectedColorFromList,
                    DogId = dog.DogId,
                    Name = dog.Name,
                    numerPKR = dog.SelectedPkrValue + "-" + dog.numerPKR,
                    PkrID = 2,
                    TattooOrChip = dog.TattooOrChip,
                    Titles = dog.Titles,
                    UserProfileId = dog.UserProfileId,
                    Breeder = dog.Breeder
                };

                db.Dogs.Add(newDog);
                db.SaveChanges();
                return RedirectToAction("Moje");
            }

            return View();
        }

        public string GetProperBreeds(string pkrName)
        {
            var breeds = new List<SelectListItem>();
            Pkr pkr = db.Pkrs.FirstOrDefault(p => p.Name.Equals(pkrName));
            List<SelectListItem> properBreedList = db.Breeds.Where(b => b.PkrID == pkr.PkrID).ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.BreedID.ToString() }).ToList();
            return new JavaScriptSerializer().Serialize(properBreedList);
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
            var userID = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Name", dog.BreedID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "NameEN", dog.ColorID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "NameEN", dog.GenderID);
            ViewBag.PkrID = new SelectList(db.Pkrs, "PkrID", "Name", dog.PkrID);
            ViewBag.UserProfileId = Convert.ToInt32(userID);
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
                return RedirectToAction("Moje");
            }
            var userID = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "Name", dog.BreedID);
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "NameEN", dog.ColorID);
            ViewBag.GenderID = new SelectList(db.Genders, "GenderID", "NameEN", dog.GenderID);
            ViewBag.PkrID = new SelectList(db.Pkrs, "PkrID", "Name", dog.PkrID);
            ViewBag.UserProfileId = Convert.ToInt32(userID);
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
            return RedirectToAction("Moje");
        }

        public ActionResult MyDogs(int? userID)
        {
            var userIDb = WebSecurity.GetUserId(User.Identity.Name);
            var UserProfileID_UserId = Convert.ToInt32(userIDb);
            userID = UserProfileID_UserId;
            var dogs = from d in db.Dogs
                       where d.UserProfile.UserProfileId == UserProfileID_UserId
                       orderby d.Name
                       select d;
            int zlicz = dogs.ToList().Count();
            if (zlicz > 0)
            {
                return View(dogs.ToList());
            }
            else
            {
                return RedirectToAction("NoDog");
            }
                       
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult NoDog()
        {
            return View();
        }

    }
}