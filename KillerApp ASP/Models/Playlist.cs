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
        public string Maker { get; set; }
        public List<Lied> liedjes = new List<Lied>();

        public Playlist(int id, string naam, int afspeelduur, string maker)
        {
            //de afspeellijsten kunnen nog niet worden opgehaald in de SQL
            //in de website moet nog een knop komen waardoor de playlists kunnen worden opgehaald zodat ze links inde lijst komen te sstaan.
            ID = id;
            Naam = naam;
            DuurBerekenen();
            Maker = maker;
        }
        public Playlist(string naam, int afspeelduur, string maker)
        {
            Naam = naam;
            Afspeelduur = afspeelduur;
            ID = -1;
            Maker = maker;
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
                DuurBerekenen();
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
                DuurBerekenen();
            }
            catch (Exception)
            {
                //hier geldt hetzelfde als bovenstaande methode.
                throw new Exception();
            }
        }

        private void DuurBerekenen()
        {
            int duur = 0;
            foreach (Lied L in liedjes)
            {
                duur += L.Duur;
            }
            Afspeelduur = duur;
        }
    }
}