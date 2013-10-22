using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShowRegSys.Models;
using ShowRegSys.DAL;

namespace ShowRegSys.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private ShowContext db = new ShowContext();

        //
        // GET: /Catalog/

        public ActionResult Index( int id = 0)
        {
            Show show = db.Shows.Find(id);

            if (show == null)
            {
                return HttpNotFound();
            }


            return View(show);
        }

    }
}
