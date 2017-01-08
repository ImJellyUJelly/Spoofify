using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KillerApp_ASP.Models;

namespace KillerApp_ASP.Controllers
{
    public class PlaylistController : Controller
    {
        Database db = new Database();
        // GET: Playlist
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PlaylistOverzicht()
        {
            List<Playlist> playlisten = db.ListPlaylists();
            return View(playlisten);
        }

        [HttpPost]
        public ActionResult AddPlaylist(Gebruiker G, string naam)
        {
            db.AddPlaylistToGebruiker(G.ID, naam);
            List<Playlist> playlisten = db.ListPlaylists();
            return View(playlisten);
        }
    }
}