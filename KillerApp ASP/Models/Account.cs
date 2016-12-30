using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public abstract class Account
    {
        public string Naam { get; set; }
        public string Wachtwoord { get; set; }
        public string Emailadres { get; set; }
        public bool Beheerder { get; set; }

        public Account(string naam, string wachtwoord, string email, bool beheerder)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
            Emailadres = email;
            Beheerder = beheerder;
        }

        public abstract void AfspeellijstVerwijderen(string naam);
    }
}