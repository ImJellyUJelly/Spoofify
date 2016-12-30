using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Beheerder : Account
    {
        public Beheerder(string naam, string wachtwoord, string email, bool beheerder) : base(naam, wachtwoord, email, beheerder)
        {
            Naam = naam;
            Wachtwoord = wachtwoord;
            Emailadres = email;
            Beheerder = true;
        }

        public override void AfspeellijstVerwijderen(string naam)
        {
            throw new NotImplementedException();
        }
    }
}