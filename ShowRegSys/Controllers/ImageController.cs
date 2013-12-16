using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.Models;
using ShowRegSys.DAL;
using PagedList;

namespace ShowRegSys.Controllers
{
    public class ImageController : Controller
    {
        private ShowContext db = new ShowContext();

        //
        // GET: /Image/

        public ActionResult Index()
        {
            return View();
        }
        //
        // GET: upload
        public ActionResult Upload(int showID)
        {
            ViewBag.showID = showID;
            return View();
        }


        //
        // POST: Upload
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file, int showID, string imageName)
        {
            try
            {
                if(file.ContentLength >0)
                {

                    ViewBag.showID = showID;
                    var fileName = Path.GetFileName(file.FileName);
                    var path1 = Path.Combine(Server.MapPath("~/Images"), fileName);
                    var path2 = string.Format("/Images/{0}", fileName);
                    file.SaveAs(path1);

                    Image image = new Image();
                    image.Path = path2;
                    image.Name = imageName;
                    image.ShowId = showID;

                    db.Images.Add(image);
                    db.SaveChanges();
                }
                ViewBag.Message = "Przesyłanie zakończone.";
                return View("AddDone");
            }
            catch (Exception e)
            {
                throw;
                ViewBag.Message = "Przesyłanie przerwane";
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddDone(int showID)
        {
            ViewBag.ShowID = showID;
            return View();
        }

        //
        //GET /ImageList/5
        public ActionResult ImageList(int showID)
        {
            var images = db.Images.Where(s => s.ShowId == showID).OrderBy(s => s.ImageId);
            var show = db.Shows.Find(showID);
            ViewBag.ShowName = show.Name;
            ViewBag.ShowId = show.ShowID;
            return View(images.ToList());
        }


        //
        //POST /ImageList/5
        public ActionResult SingleImage(int imageId, int showId)
        {
            var images = db.Images.Where(s => s.ShowId == showId).OrderBy(s => s.ImageId).ToArray();
            ViewBag.CurrentImageId = imageId;
            ViewBag.CurrentShowId = showId;

            var nextImg = images.FirstOrDefault(i => i.ImageId > imageId);
            if(nextImg == null)
            {
                ViewBag.NextImageId = imageId;
            }
            else
            {
                int nextId = nextImg.ImageId;
                ViewBag.NextImageId = nextId;
            }

            var prevImg = images.LastOrDefault(i => i.ImageId < imageId);
            if(prevImg == null)
            {
                ViewBag.PrevImageId = imageId;
            }
            else
            {
                int prevId = prevImg.ImageId;
                ViewBag.PrevImageId = prevId;
            }
            
            var image = db.Images.Find(imageId);
            return View(image);
        }


        //
        //GET /Image/ImageAdmin/5
        public ActionResult ImageAdmin(int? page, int id = 0)
        {
            var images = db.Images.Where(s => s.ShowId == id).OrderBy(s => s.ImageId);
            var show = db.Shows.Find(id);
            ViewBag.ShowName = show.Name;
            ViewBag.ShowId = show.ShowID;

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            int zlicz = images.ToList().Count();

            if(zlicz > 0)
            {
                return View(images.ToPagedList(pageNumber, pageSize));
            }
            else
            {
                return RedirectToAction("NoImage");
            }
            
            
            return View(images.ToList());
        }

        //
        //GET Image/Delete/5
        public ActionResult Delete(int id = 0, int showId = 0)
        {
            Image image = db.Images.Find(id);
            if( image == null )
            {
                return HttpNotFound();
            }
            ViewBag.ShowId = showId;
            return View(image);
        }

        //
        //POST /Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int showId)
        {
            Image image = db.Images.Find(id);
            db.Images.Remove(image);
            db.SaveChanges();
            string path = image.Path;
            System.IO.File.Delete(Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory + Path.Combine(Server.MapPath("~/Images"), path)));


            return RedirectToAction("ImageAdmin", new { showID = showId });
        }
    }
}
