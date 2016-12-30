using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp_ASP.Models;

namespace KillerApp_ASP.Controllers
{
    public class BandController : Controller
    {
        Database db = new Database();
        // GET: Band
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Band()
        {
            List<Band> bands = db.ListBands();
            return View(bands);
        }
    }
}