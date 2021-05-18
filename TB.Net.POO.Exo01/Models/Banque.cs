using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Banque
    {
        //private string _nomBanque;

        private Dictionary<string, Compte> _comptes = new Dictionary<string, Compte>();


        //public string Nom
        //{
        //    get { return _nomBanque; }
        //    set { _nomBanque = value;  }
        //}

        public string Nom { get; set; }

        public Compte this[string numero]
        {
            get {
                Compte c;
                _comptes.TryGetValue(numero, out c);
                if (c is null) return c; //Gestion d'erreur
                return c;
            }
        }

        public void Ajouter(Compte courant)
        {
            if (_comptes.ContainsValue(courant)) return; //Gestion d'erreur
            _comptes.Add(courant.Numero, courant);
        }

        public void Supprimer(string numero)
        {
            if (!_comptes.ContainsKey(numero)) return; //Gestion d'erreur
            _comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne titulaire)
        {
            double avoirs = 0;
            foreach (Compte compte in _comptes.Values)
            {
                if (compte.Titulaire == titulaire) avoirs = avoirs + compte;
            }
            return avoirs;
        }

    }
}
