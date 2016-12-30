using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Muzikant
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public int Telefoonnummer { get; set; }
        public string Emailadres { get; set; }

        public Muzikant(int id, string naam, int tel, string email)
        {
            ID = id;
            Naam = naam;
            Telefoonnummer = tel;
            Emailadres = email;
        }
        public Muzikant(string naam, int tel, string email)
        {
            Naam = naam;
            Telefoonnummer = tel;
            Emailadres = email;
        }
    }
}