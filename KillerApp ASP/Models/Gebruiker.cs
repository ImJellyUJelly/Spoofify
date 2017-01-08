using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Gebruiker : Account
    {
        public List<Playlist> Afspeellijsten = new List<Playlist>();
        public List<Gebruiker> Friends = new List<Gebruiker>();
        public Gebruiker(int id, string naam, string wachtwoord, string email, bool beheerder) : base(naam, wachtwoord, email, beheerder)
        {
            ID = id;
            Naam = naam;
            Wachtwoord = wachtwoord;
            Emailadres = email;
            Beheerder = false;
        }
        public Gebruiker(int id, string naam, string wachtwoord) : base(id, naam, wachtwoord)
        {
            ID = id;
            Naam = naam;
            Wachtwoord = wachtwoord;
        }
        public bool AfspeellijstAanmaken(string naam)
        {
            foreach (Playlist P in Afspeellijsten)
            {
                if (P.Naam != naam)
                {
                    Afspeellijsten.Add(new Playlist(naam));
                    return true;
                }
            }
            return false;
        }
        public override void AfspeellijstVerwijderen(string naam)
        {
            foreach (Playlist P in Afspeellijsten)
            {
                if (P.Naam == naam)
                {
                    Afspeellijsten.Remove(P);
                }
            }
        }
    }
}