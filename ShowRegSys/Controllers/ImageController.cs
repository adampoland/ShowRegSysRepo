using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.Models;
using ShowRegSys.DAL;

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
                ViewBag.Message = "Upload successful";
                return View("AddDone");
            }
            catch (Exception e)
            {
                throw;
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Index");
            }
        }

        public ActionResult AddDone(int showID)
        {
            ViewBag.ShowID = showID;
            return View();
        }

        public ActionResult ImageList(int showID)
        {
            var images = db.Images.Where(s => s.ShowId == showID).OrderBy(s => s.ImageId);
            return View(images.ToList());
        }

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
    }
}
