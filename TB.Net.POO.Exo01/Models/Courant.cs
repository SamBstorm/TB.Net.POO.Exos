﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;
        private double _solde;

        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set { 
                if (value < 0) return;      //return doit être remplacer par une gestion d'erreur
                _ligneDeCredit = value;
            }//set { if (value >= 0) _ligneDeCredit = value; }
        }

        public override void Retrait(double montant) {
            base.Retrait(montant, LigneDeCredit);
        }
        
    }
}
