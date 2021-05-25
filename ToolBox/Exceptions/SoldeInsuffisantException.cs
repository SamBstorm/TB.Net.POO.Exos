using System;
using System.Collections.Generic;
using System.Text;

namespace ToolBox.Exceptions
{
    public class SoldeInsuffisantException : Exception
    {
        public double AskMontant { get; private set; }
        public double CurrentSolde { get; private set; }
        public double NegativLimit { get; private set; }

        public SoldeInsuffisantException() : base ("Solde insuffisant pour le retrait demandé")
        {

        }

        public SoldeInsuffisantException(string message) : base(message)
        {

        }
        public SoldeInsuffisantException(string message, double montant, double solde, double limite) : this(message)
        {
            AskMontant = montant;
            CurrentSolde = solde;
            NegativLimit = limite;
        }

        public SoldeInsuffisantException(double montant, double solde, double limite) : this($"Le solde de votre compte ({solde}) et votre limite ({limite}), ne vous permettent pas d'éffecteur le retrait de {montant}.",solde, montant, limite)
        {
        }

        public double GetDifference()
        {
            return (CurrentSolde + NegativLimit) - AskMontant;
        }
    }
}
