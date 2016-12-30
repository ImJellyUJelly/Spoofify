using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Lied
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public int Duur { get; set; }
        public Genre Genrenaam { get; set; }
        public Band Band { get; set; }
        public Album Album { get; set; }


        public Lied(int id, string titel, int duur, Genre genre, Band band, Album album)
        {
            ID = id;
            Titel = titel;
            Duur = duur;
            Genrenaam = genre;
            Band = band;
            Album = album;
        }
        public Lied(string titel, int duur, Genre genre, Band band, Album album)
        {
            Titel = titel;
            Duur = duur;
            Genrenaam = genre;
            Band = band;
            Album = album;
        }
    }
}