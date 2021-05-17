using System;
using TB.Net.POO.Exo01.Models;

namespace TB.Net.POO.Exo01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test Exo01
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
            #endregion
            #region Test Exo02
            Banque b = new Banque();

            b.Nom = "BanqueRoute";

            b.Ajouter(c);
            Courant c2 = b[c.Numero];
            if (c == c2) Console.WriteLine("Il s'agit du même compte!");

            b.Ajouter(c2);
            b.Supprimer(c2.Numero);
            #endregion

        }
    }
}
