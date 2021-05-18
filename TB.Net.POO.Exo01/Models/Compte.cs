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
        public static double operator +(Compte left, Compte right)
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


        public static double operator +(double left, Compte right)
        {
            double solde1 = 0, solde2 = 0;
            if (left > 0) solde1 = left;
            if (right.Solde > 0) solde2 = right.Solde;
            return solde1 + solde2;

            //return ((left > 0) ? left : 0) + ((right.Solde > 0) ? right.Solde : 0);
        }
    }
}
