using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Playlist
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public int Afspeelduur { get; set; }
        List<Lied> liedjes = new List<Lied>();

        public Playlist(int id, string naam, int afspeelduur)
        {
            ID = id;
            Naam = naam;
            Afspeelduur = afspeelduur;
        }
        public Playlist(string naam, int afspeelduur)
        {
            Naam = naam;
            Afspeelduur = afspeelduur;
            ID = -1;
        }
        public Playlist(string naam)
        {
            Naam = naam;
            Afspeelduur = -1;
            ID = -1;
        }

        public void LiedToevoegen(Lied lied)
        {
            if (!liedjes.Contains(lied))
            {
                liedjes.Add(lied);
            }
            else
            {
                //moet nog een exceptie voor gemaakt worden.
                throw new Exception();
            }
        }
        public void LiedVerwijderen(Lied lied)
        {
            try
            {
                liedjes.Remove(lied);
            }
            catch (Exception)
            {
                //hier geldt hetzelfde als bovenstaande methode.
                throw new Exception();
            }
        }
    }
}