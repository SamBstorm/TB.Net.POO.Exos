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
            Courant c2 = (Courant)b[c.Numero];
            if (c == c2) Console.WriteLine("Il s'agit du même compte!");

            b.Ajouter(c2);
            b.Supprimer(c2.Numero);
            #endregion
            #region Test Exo03
            c = new Courant();
            c.Titulaire = p;
            c.Numero = "BE5501";
            c.Depot(300);

            b.Ajouter(c);

            c = new Courant();
            c.Titulaire = p;
            c.Numero = "BE5502";
            c.LigneDeCredit = 200;
            c.Retrait(50);

            b.Ajouter(c);

            c = new Courant();
            c.Titulaire = new Personne() { Nom="Bastin", Prenom="Diego", DateNaiss=new DateTime(1995,03,02)};
            c.Numero = "BE5503";
            c.LigneDeCredit = 200;
            c.Depot(50);

            b.Ajouter(c);

            Console.WriteLine($"Les avoirs de M.{p.Nom} sont de {b.AvoirDesComptes(p)}€.");
            Console.WriteLine($"Les avoirs de M.{c.Titulaire.Nom} sont de {b.AvoirDesComptes(c.Titulaire)}€.");
            #endregion
            #region Test Exo04

            Epargne e = new Epargne();
            e.Numero = "BE3301";
            e.Titulaire = p;
            e.Depot(50000);
            e.Retrait(60000);
            Console.WriteLine($"Le solde du compte {e.Numero}, appartenant à {e.Titulaire.Nom}, est de {e.Solde}");
            Console.WriteLine($"Le dernier retrait date de {e.DateDernierRetrait}");
            e.Retrait(30000);
            Console.WriteLine($"Le solde du compte {e.Numero}, appartenant à {e.Titulaire.Nom}, est de {e.Solde}");
            Console.WriteLine($"Le dernier retrait date de {e.DateDernierRetrait}");

            #endregion
            #region Test Exo05

            b.Ajouter(e);

            Console.WriteLine($"Les avoirs de M.{p.Nom} sont de {b.AvoirDesComptes(p)}€.");
            Console.WriteLine($"Les avoirs de M.{c.Titulaire.Nom} sont de {b.AvoirDesComptes(c.Titulaire)}€.");

            #endregion
            #region Test Exo06
            Console.WriteLine($"Le compte courant {c.Numero} a pour Solde {c.Solde}");
            Console.WriteLine($"Le compte courant {e.Numero} a pour Solde {e.Solde}");
            c.AppliquerInteret();
            e.AppliquerInteret();
            Console.WriteLine($"Le compte courant {c.Numero} a pour Solde {c.Solde}");
            Console.WriteLine($"Le compte courant {e.Numero} a pour Solde {e.Solde}");
            c.Retrait(65);
            Console.WriteLine($"Le compte courant {c.Numero} a pour Solde {c.Solde}");
            c.AppliquerInteret();
            Console.WriteLine($"Le compte courant {c.Numero} a pour Solde {c.Solde}");
            #endregion
        }
    }
}
