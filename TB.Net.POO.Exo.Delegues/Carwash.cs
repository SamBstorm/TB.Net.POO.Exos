using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo.Delegues
{
    public class Carwash
    {
        public TraitementVoiture traitement = null;

        public Carwash()
        {
            #region Exo01 des délégués
            //traitement = Preparer;
            //traitement += Laver;
            //traitement += Secher;
            //traitement += Finaliser; 
            #endregion
            #region Exo02 méthodes anonymes
            traitement = delegate (Voiture v) { Console.WriteLine($"Je prépare la voiture : {v.Plaque}") ; };
            traitement += delegate (Voiture v) { Console.WriteLine($"Je lave la voiture : {v.Plaque}") ; };
            traitement += delegate (Voiture v) { Console.WriteLine($"Je sèche la voiture : {v.Plaque}") ; };
            traitement += delegate (Voiture v) { Console.WriteLine($"Je finalise la voiture : {v.Plaque}") ; };
            #endregion
        }

        private void Preparer(Voiture v)
        {
            Console.WriteLine($"Je prépare la voiture : {v.Plaque}");
        }
        private void Laver(Voiture v)
        {
            Console.WriteLine($"Je lave la voiture : {v.Plaque}");
        }
        private void Secher(Voiture v)
        {
            Console.WriteLine($"Je sèche la voiture : {v.Plaque}");
        }
        private void Finaliser(Voiture v)
        {
            Console.WriteLine($"Je finalise la voiture : {v.Plaque}");
        }

        public void Traiter(Voiture v) {
            traitement(v);
        }
    }
}
