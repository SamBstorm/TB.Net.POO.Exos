using System;
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

        public static double operator +(Courant left, Courant right)
        {
            double solde1 = 0, solde2 = 0;
            if (left.Solde > 0) solde1 = left.Solde;
            if (right.Solde > 0) solde2 = right.Solde;
            return solde1 + solde2;

            //return ((left.Solde > 0) ? left.Solde : 0) + ((right.Solde > 0) ? right.Solde : 0);
        }
        /*
         il faut juste définir que si le nombre est négatif, j'additionne 0 à la place de sa vrai valeur
 
        exemple :
        200 + 500 => 700
        200 + -50 => 200 + 0 => 200
        -100 + 70 => 0 + 70 => 70
        -30 + -20 => 0 + 0 => 0
         */


        public static double operator +(double left, Courant right)
        {
            double solde1 = 0, solde2 = 0;
            if (left > 0) solde1 = left;
            if (right.Solde > 0) solde2 = right.Solde;
            return solde1 + solde2;

            //return ((left > 0) ? left : 0) + ((right.Solde > 0) ? right.Solde : 0);
        }
    }
}
