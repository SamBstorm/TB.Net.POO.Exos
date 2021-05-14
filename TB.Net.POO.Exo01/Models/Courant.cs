using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Courant
    {
        public string Numero { get; set; }
        public Personne Titulaire { get; set; }
        private double _ligneDeCredit;

        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set { 
                if (value < 0) return;      //return doit être remplacer par une gestion d'erreur
                _ligneDeCredit = value;
            }//set { if (value >= 0) _ligneDeCredit = value; }
        }

        private double _solde;

        public double Solde
        {
            get { return _solde; }
            //private set { _solde = value; }
        }

        public void Retrait(double montant) {
            if (montant <= 0) return;      //return doit être remplacer par une gestion d'erreur
            if (montant > Solde + LigneDeCredit) return;      //return doit être remplacer par une gestion d'erreur
            _solde -= montant;
        }
        public void Depot(double montant) {
            if (montant <= 0) return;      //return doit être remplacer par une gestion d'erreur
            _solde += montant;
        }

    }
}
