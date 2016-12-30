using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Muziekspeler
    {
        Database db = new Database();
        public Muziekspeler()
        {

        }

        public List<Band> BandOverzicht()
        {
            return db.ListBands();
        }
        public List<Lied> LiedOverzicht()
        {
            return db.ListLiedjes();
        }
        public List<Album> AlbumOverzicht()
        {
            return db.ListAlbums();
        }
        public List<Playlist> PlaylistOverizcht()
        {
            return db.ListPlaylists();
        }
    }
}