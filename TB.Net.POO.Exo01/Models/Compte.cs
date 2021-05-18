using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Compte
    {
        private double _solde;
        public string Numero { get; set; }
        public Personne Titulaire { get; set; }
        public double Solde { get { return _solde; } }

        public void Depot(double montant)
        {
            if (montant <= 0) return;
            _solde += montant;
        }

        protected void Retrait(double montant, double limite)
        {
            if (montant <= 0) return;
            if (montant > Solde + limite) return;
            _solde -= montant;
        }

        public virtual void Retrait(double montant)
        {
            this.Retrait(montant, 0);
        }
    }
}
