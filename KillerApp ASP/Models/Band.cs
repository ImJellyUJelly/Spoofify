using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KillerApp_ASP.Models
{
    public class Band
    {
        public int ID { get; set; }
        public string Naam { get; set; }
        public int OpgerichtJaartal { get; set; }

        public Band(int id, string naam, int jaartal)
        {
            ID = id;
            Naam = naam;
            OpgerichtJaartal = jaartal;
        }
        public Band(string naam, int jaartal)
        {
            ID = -1;
            Naam = naam;
            OpgerichtJaartal = jaartal;
        }
        public Band(int id)
        {
            ID = id;
        }
    }
}