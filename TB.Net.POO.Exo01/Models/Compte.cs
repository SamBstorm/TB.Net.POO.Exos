using System;
using System.Collections.Generic;
using System.Text;
using ToolBox.Exceptions;

namespace TB.Net.POO.Exo01.Models
{
    public abstract class Compte : IBanker
    {
        private double _solde;
        public string Numero { get; private set; }
        public Personne Titulaire { get; private set; }
        public double Solde { get { return _solde; } }

        public event Action<Compte> PassageEnNegatifEvent;

        public Compte(string numero, Personne titulaire)
        {
            this.Numero = numero;
            this.Titulaire = titulaire;
            this.PassageEnNegatifEvent = null;
        }
        public Compte(string numero, Personne titulaire, double solde) : this(numero, titulaire)
        {
            this._solde = solde;
        }

        public void Depot(double montant)
        {
            if (montant <= 0) throw new ArgumentOutOfRangeException($"Le montant : {montant} ; est inférieur ou égale à zéro, veuillez indiquer un montant supérieur.");
            _solde += montant;
        }

        protected void Retrait(double montant, double limite)
        {
            if (montant <= 0) throw new ArgumentOutOfRangeException($"Le montant : {montant} ; est inférieur ou égale à zéro, veuillez indiquer un montant supérieur.");
            if (montant > Solde + limite) throw new SoldeInsuffisantException(Solde,montant,limite);
            _solde -= montant;
        }

        public void AppliquerInteret()
        {
            _solde += CalculerInteret();
        }

        public abstract void Retrait(double montant);

        protected abstract double CalculerInteret();
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

        protected void PassageEnNegatifRaise(Compte compte)
        {
            //if(!(PassageEnNegatifEvent is null))this.PassageEnNegatifEvent(compte);
            this.PassageEnNegatifEvent?.Invoke(compte);
        }
    }
}
