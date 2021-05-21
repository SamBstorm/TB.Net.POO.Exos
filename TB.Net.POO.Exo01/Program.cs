using System;
using TB.Net.POO.Exo01.Models;

namespace TB.Net.POO.Exo01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Test Exo01
            Personne p = new Personne("Legrain","Samuel",new DateTime(1987, 9, 27));

            Courant c = new Courant("BE54736489001234",p,-200);
            c.Depot(5000000);
            c.Retrait(-500000);

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
            c = new Courant("BE5501",p);
            c.Depot(300);

            b.Ajouter(c);

            c = new Courant("BE5502",p,200);
            c.Retrait(50);

            b.Ajouter(c);

            c = new Courant("BE5503",new Personne("Bastin", "Diego", new DateTime(1995,03,02)), 200);
            c.Depot(50);

            b.Ajouter(c);

            Console.WriteLine($"Les avoirs de M.{p.Nom} sont de {b.AvoirDesComptes(p)}€.");
            Console.WriteLine($"Les avoirs de M.{c.Titulaire.Nom} sont de {b.AvoirDesComptes(c.Titulaire)}€.");
            #endregion
            #region Test Exo04

            Epargne e = new Epargne("BE3301",p);
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
            #region Test Exo07
            ICustomer customer = c;
            Console.WriteLine($"En tant que client du compte je peut voir mon Solde : {customer.Solde}");
            customer.Depot(500);
            Console.WriteLine($"En tant que client du compte je peut voir mon Solde : {customer.Solde}");
            IBanker banquier = c;
            Console.WriteLine($"En tant que banquier je peux voir le Solde : {banquier.Solde} ; le titulaire {banquier.Titulaire.Nom} ; et le numéro {banquier.Numero}");
            banquier.AppliquerInteret();
            Console.WriteLine($"En tant que banquier je peux voir le Solde : {banquier.Solde} ; le titulaire {banquier.Titulaire.Nom} ; et le numéro {banquier.Numero}");

            #endregion
        }
    }
}
