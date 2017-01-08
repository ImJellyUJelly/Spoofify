using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using KillerApp_ASP.Models;

namespace KillerApp_ASP.Controllers
{

    public class AccountController : Controller
    {
        Database db = new Database();
        private Gebruiker user;
        // GET: Authentication
        public ActionResult Index()
        {
            user = (Gebruiker)Session["user"];
            return View();
        }

        //public ActionResult CheckLogin(string naam, string password)
        //{
        //    if (naam == null && password == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    if (db.Login(naam, password))
        //    {
        //        Session["User"] = db.GetGebruikerByNaam(naam, password);
        //        user = (Gebruiker)Session["User"];
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return RedirectToAction("Index", "Account");
        //    }

        //}

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {
            string naam = form["naam"];
            string wachtwoord = form["wachtwoord"];
            if (naam == null && wachtwoord == null)
            {
                return HttpNotFound();
            }
            else if (naam != null && wachtwoord != null)
            {
                Gebruiker gebruiker = db.GetGebruikerByNaam(naam, wachtwoord);
                Session["Gebruiker"] = gebruiker;
                //user = (Gebruiker)Session["Gebruiker"];
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Authentication");
            }

        }
    }
}