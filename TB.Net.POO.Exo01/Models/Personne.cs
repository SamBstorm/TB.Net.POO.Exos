using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Personne
    {
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        public DateTime DateNaiss { get; private set; }
        public Personne(string nom, string prenom, DateTime dateNaiss)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.DateNaiss = dateNaiss;
        }
    }
}
