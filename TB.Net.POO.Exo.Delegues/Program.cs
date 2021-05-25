using System;

namespace TB.Net.POO.Exo.Delegues
{
    class Program
    {
        static void Main(string[] args)
        {
            Voiture v1 = new Voiture("1-ABC-123");
            Voiture v2 = new Voiture("1-MOP-123");
            Voiture v3 = new Voiture("1-XYZ-123");

            Carwash cw = new Carwash();

            cw.Traiter(v1);
            cw.Traiter(v2);
            cw.Traiter(v3);

        }
    }
}
