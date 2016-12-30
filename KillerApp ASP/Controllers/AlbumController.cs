using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp_ASP.Models;

namespace KillerApp_ASP.Controllers
{
    public class AlbumController : Controller
    {
        Database db = new Database();
        // GET: Album
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Album()
        {
            List<Album> albums = db.ListAlbums();
            return View(albums);
        }
    }
}