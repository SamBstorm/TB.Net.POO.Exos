using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Epargne
    {
        private double _solde;
        public string Numero { get; set; }
        public Personne Titulaire { get; set; }
        public DateTime DateDernierRetrait { get; set; }

        public double Solde { get { return _solde; } }

        public void Retrait(double montant)
        {
            if (montant <= 0) return;
            if (montant > Solde) return;
            _solde -= montant;
            DateDernierRetrait = DateTime.Now;
        }

        public void Depot(double montant)
        {
            if (montant <= 0) return;
            _solde += montant;
        }
    }
}
