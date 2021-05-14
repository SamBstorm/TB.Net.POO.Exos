using System;
using TB.Net.POO.Exo01.Models;

namespace TB.Net.POO.Exo01
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p = new Personne();
            p.Nom = "Legrain";
            p.Prenom = "Samuel";
            p.DateNaiss = new DateTime(1987, 9, 27);

            Courant c = new Courant();
            c.Numero = "BE54736489001234";
            c.LigneDeCredit = -200;
            c.Depot(5000000);
            c.Retrait(-500000);

            #region Soit une nouvelle instance
            c.Titulaire = new Personne();
            c.Titulaire.Nom = "Legrain";
            c.Titulaire.Prenom = "Samuel";
            c.Titulaire.DateNaiss = new DateTime(1987, 9, 27);
            #endregion

            #region Soit une instance existante
            c.Titulaire = p; 
            #endregion

            if (c.Titulaire == p) Console.WriteLine("Ce sont les même!!!");
        }
    }
}
