using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp_ASP.Models;

namespace KillerApp_ASP.Controllers
{
    public class FriendfeedController : Controller
    {
        Database db = new Database();
        // GET: Friendfeed
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Friendfeed()
        {
            List<Vriend> vrienden = new List<Vriend>();
            vrienden = db.GetFriends(1);
            return View(vrienden);
        }
    }
}