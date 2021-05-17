using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public class Banque
    {
        //private string _nomBanque;

        private Dictionary<string, Courant> _comptes = new Dictionary<string, Courant>();


        //public string Nom
        //{
        //    get { return _nomBanque; }
        //    set { _nomBanque = value;  }
        //}

        public string Nom { get; set; }

        public Courant this[string numero]
        {
            get {
                Courant c;
                _comptes.TryGetValue(numero, out c);
                if (c is null) return c; //Gestion d'erreur
                return c;
            }
        }

        public void Ajouter(Courant courant)
        {
            if (_comptes.ContainsValue(courant)) return; //Gestion d'erreur
            _comptes.Add(courant.Numero, courant);
        }

        public void Supprimer(string numero)
        {
            if (!_comptes.ContainsKey(numero)) return; //Gestion d'erreur
            _comptes.Remove(numero);
        }

    }
}
