using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Album
    {
        public int ID { get; set; }
        public string Titel { get; set; }
        public int Uitgiftejaar { get; set; }
        public string Single { get; set; }

        public Album(int id, string titel, int jaar, string single)
        {
            ID = id;
            Titel = titel;
            Uitgiftejaar = jaar;
            Single = single;
        }
        public Album(string titel, int jaar, string single)
        {
            Titel = titel;
            Uitgiftejaar = jaar;
            Single = single;
        }
        public Album(int id)
        {
            ID = id;
        }

        public override string ToString()
        {
            return $"{ Titel }, ";
        }
    }
}