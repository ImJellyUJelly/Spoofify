using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp_ASP.Models;

namespace KillerApp_ASP.Controllers
{
    public class AuthenticationController : Controller
    {
        private Gebruiker user;
        Database db = new Database();
        // GET: Authentication
        public ActionResult Index()
        {
            user = (Gebruiker)Session["User"];
            return View();
        }

        //oke, ff in de comments, dan zie je het.
        //Hieronder moet ie dus checken of de data die hij gekregen heeft van Login.cshtml klopt, ofja, aan de db vragen, maar waarom doet ie het niet?
        // Heb je al met debug gekeken of hij hier komt?
        //nou hij komt hier idd niet, dan zegt ie dat de destination unreachable is, maar.. why?
        //Bij de mijne is mijn ActionResult dezelfde naam als de View
        //moet dat per se?
        //Ik zou van de Login controller - action ding waar je dus de login gegevens invoert een HttpGet en HttpPost van maken
        //uuuuuuh?? Mag ik iets proberen? Ja ga je gang

        [HttpGet]
        [ValidateAntiForgeryToken]
        public ActionResult CheckLogin(string naam, string wachtwoord)
        {
            if (naam == null && wachtwoord == null)
            {
                return HttpNotFound();
            }
            if (db.Login(naam, wachtwoord))
            {
                Session["Gebruiker"] = db.GetGebruikerByNaam(naam, wachtwoord);
                user = (Gebruiker)Session["Gebruiker"];
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Authentication");
            }

        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Authentication");
        }
    }
}