using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Epargne : Compte
    {
        private double _interet = 0.045;
        public DateTime DateDernierRetrait { get; set; }

        public override void Retrait(double montant)
        {
            base.Retrait(montant,0);
            DateDernierRetrait = DateTime.Now; //Grace aux exceptions nous éviterons de déclancher l'enrgistrement de la date
        }

        protected override double CalculerInteret()
        {
            return Solde * _interet;
        }
    }
}
