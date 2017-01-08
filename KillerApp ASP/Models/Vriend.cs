using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Vriend
    {
        public int ID { get; set; }
        public string Naam { get; set; }

        public Vriend(int id, string naam)
        {
            ID = id;
            Naam = naam;
        }
        public Vriend(string naam)
        {
            Naam = naam;
        }
    }
}