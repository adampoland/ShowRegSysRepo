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

        //--------------------------------------
        //------------GET: /Dog/---------------
        //--------------------------------------
        [AllowAnonymous]
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

        [AllowAnonymous]
        public ActionResult Details( DogDetailsViewModel dogDetails, int? page, int id = 0)
        {

            Dog dog = db.Dogs.Find(id);

            if (dog == null)
            {
                return HttpNotFound();
            }

            var enrol = db.Enrollments.Where(e => e.DogID == dog.DogId).OrderBy(e => e.EnrollmentID);
            var pageIndex = dogDetails.Page ?? 1; //to samo co pageNumber
            int pageSize = 5;

            dogDetails.Name = dog.Name;
            dogDetails.numerPKR = dog.numerPKR;
            dogDetails.PkrName = dog.Pkr.Name;
            dogDetails.BreedName = dog.Breed.Name;
            dogDetails.ColorName = dog.Color.NamePL;
            dogDetails.GenderName = dog.Gender.NamePL;
            dogDetails.TattooOrChip = dog.TattooOrChip;
            dogDetails.Breeder = dog.Breeder;
            dogDetails.BirthDate = dog.BirthDate;
            dogDetails.Titles = dog.Titles;
            dogDetails.EnrollmentPagedList = enrol.ToPagedList(pageIndex, pageSize);

            return View(dogDetails);
        }

        //
        // GET: /Dog/Create

        public ActionResult Create()
        {
            DogCreateViewModel dog = new DogCreateViewModel();
            dog.UserProfileId = WebSecurity.GetUserId(User.Identity.Name);
            dog.GenderList = db.Genders.ToList().Select(u => new SelectListItem { Text = u.NamePL, Value = u.GenderID.ToString() }).ToList();
            dog.ColorList = db.Colors.ToList().Select(u => new SelectListItem { Text = u.NamePL, Value = u.ColorID.ToString() }).ToList();
            dog.PkrList = db.Pkrs.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.Name }).ToList();
            dog.BreedList = db.Breeds.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.BreedID.ToString() }).ToList();
            return View(dog);
        }

        //
        // POST: /Dog/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DogCreateViewModel dog)
        {
            if (ModelState.IsValid)
            {
                int getPkrID = (from m in db.Pkrs
                             where m.Name == dog.SelectedPkrValue
                             select m.PkrID).First();


                Dog newDog = new Dog()
                {
                    BirthDate = dog.BirthDate,
                    GenderID = dog.SelectedGenderFromList,
                    BreedID = dog.SelectedBreedFromList,
                    ColorID = dog.SelectedColorFromList,
                    DogId = dog.DogId,
                    Name = dog.Name,
                    numerPKR = dog.PkrNumber,
                    PkrID = getPkrID,
                    TattooOrChip = dog.TattooOrChip,
                    Titles = dog.Titles,
                    UserProfileId = dog.UserProfileId,
                    Breeder = dog.Breeder
                };

                db.Dogs.Add(newDog);
                db.SaveChanges();
                return RedirectToAction("MyDogs");
            }

            return View();
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

            DogCreateViewModel dogEdit = new DogCreateViewModel()
            {
                DogId = dog.DogId,
                Name = dog.Name,
                PkrNumber = dog.numerPKR,
                SelectedBreedFromList = dog.BreedID,
                SelectedColorFromList = dog.ColorID,
                SelectedGenderFromList = dog.GenderID,
                TattooOrChip = dog.TattooOrChip,
                UserProfileId = userID,
                Breeder = dog.Breeder,
                BirthDate = dog.BirthDate,
                Titles = dog.Titles,
                SelectedPkrValue = dog.Pkr.Name
            };
            dogEdit.GenderList = db.Genders.ToList().Select(u => new SelectListItem { Text = u.NameEN, Value = u.GenderID.ToString() }).ToList();
            dogEdit.ColorList = db.Colors.ToList().Select(u => new SelectListItem { Text = u.NameEN, Value = u.ColorID.ToString() }).ToList();
            dogEdit.PkrList = db.Pkrs.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.Name }).ToList();
            dogEdit.BreedList = db.Breeds.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.BreedID.ToString() }).ToList();

            return View(dogEdit);
        }

        //
        // POST: /Dog/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DogCreateViewModel dogEdit)
        {
            var userID = WebSecurity.GetUserId(User.Identity.Name);

            if (ModelState.IsValid)
            {
                int getPkrID = (from m in db.Pkrs
                                where m.Name == dogEdit.SelectedPkrValue
                                select m.PkrID).First();

                Dog dogEdits = new Dog()
                {
                    BirthDate = dogEdit.BirthDate,
                    GenderID = dogEdit.SelectedGenderFromList,
                    BreedID = dogEdit.SelectedBreedFromList,
                    ColorID = dogEdit.SelectedColorFromList,
                    DogId = dogEdit.DogId,
                    Name = dogEdit.Name,
                    numerPKR = dogEdit.PkrNumber,
                    PkrID = getPkrID,
                    TattooOrChip = dogEdit.TattooOrChip,
                    Titles = dogEdit.Titles,
                    UserProfileId = dogEdit.UserProfileId,
                    Breeder = dogEdit.Breeder
                };
                

                db.Entry(dogEdits).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MyDogs");
            }
            dogEdit.GenderList = db.Genders.ToList().Select(u => new SelectListItem { Text = u.NameEN, Value = u.GenderID.ToString() }).ToList();
            dogEdit.ColorList = db.Colors.ToList().Select(u => new SelectListItem { Text = u.NameEN, Value = u.ColorID.ToString() }).ToList();
            dogEdit.PkrList = db.Pkrs.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.Name }).ToList();
            dogEdit.BreedList = db.Breeds.ToList().Select(u => new SelectListItem { Text = u.Name, Value = u.BreedID.ToString() }).ToList();


            return View(dogEdit);

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
            var enrol = db.Enrollments.Where(e => e.DogID == dog.DogId).ToList();
            foreach (var item in enrol)
            {
                db.Enrollments.Remove(item);
                db.SaveChanges();
            }

            db.Dogs.Remove(dog);
            db.SaveChanges();
            return RedirectToAction("MyDogs");
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

        public ActionResult GetProperBreeds(string pkrName)
        {
            var breeds = new List<SelectListItem>();
            Pkr pkr = db.Pkrs.FirstOrDefault(p => p.Name.Equals(pkrName));
            var properBreedList = db.Breeds.Where(b => b.PkrID == pkr.PkrID);

            return Json(new SelectList(properBreedList, "BreedID", "Name"));
        }
    }
}