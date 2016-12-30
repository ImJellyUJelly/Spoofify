using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp_ASP.Models;

namespace KillerApp_ASP.Controllers
{
    public class LiedController : Controller
    {
        Database db = new Database();
        // GET: Lied
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Liedoverzicht()
        {
            List<Lied> liedjes = db.ListLiedjes();
            return View(liedjes);
        }

        public ActionResult AddToPlaylist(int id, Playlist pl)
        {
            pl.liedjes.Add(db.GetLiedById(id));
            return RedirectToAction("Liedoverzicht", "Lied");
        }
    }
}