using System;
using System.Collections.Generic;
using System.Text;

namespace TB.Net.POO.Exo01.Models
{
    public interface IBanker : ICustomer
    {
        string Numero { get; }
        Personne Titulaire { get; }
        void AppliquerInteret();

    }
}
