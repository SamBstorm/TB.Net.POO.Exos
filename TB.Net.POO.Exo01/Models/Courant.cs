using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Courant : Compte
    {
        private double _ligneDeCredit;
        private double _interetPositif = 0.03;
        private double _interetNegatif = 0.0975;

        public double LigneDeCredit
        {
            get { return _ligneDeCredit; }
            set {
                if (value < 0) throw new InvalidOperationException("La ligne de crédit doit être supérieur ou égale à 0.");
                _ligneDeCredit = value;
            }//set { if (value >= 0) _ligneDeCredit = value; }
        }
        public Courant(string numero, Personne titulaire) : base(numero, titulaire)
        {

        }

        public Courant(string numero, Personne titulaire, double ligneDeCredit) : this(numero, titulaire,default(double),ligneDeCredit)
        {
        }

        public Courant(string numero, Personne titulaire, double solde, double ligneDeCredit): base(numero, titulaire, solde)
        {
            this.LigneDeCredit = ligneDeCredit;
        }

        public override void Retrait(double montant) {
            bool alreadyNegatif = this.Solde < 0;
            base.Retrait(montant, LigneDeCredit);
            if (!alreadyNegatif && Solde < 0) PassageEnNegatifRaise(this);
        }

        protected override double CalculerInteret()
        {
            return (Solde > 0) ? Solde * _interetPositif : Solde * _interetNegatif;
        }
    }
}
