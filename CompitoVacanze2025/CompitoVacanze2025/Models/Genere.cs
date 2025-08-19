using AnrangoRamosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Models
{
    internal class Genere
    {
        public int IdGenere {  get; set; }
        private string genere;

        public string Genre
        {
            get { return genere; }
            set
            {
                if (RegexUtilities.CheckSafeTitle(value, 50)) genere = value;
                else throw new ArgumentException("Il genere inserito non è valido");
            }
        }
        public Genere(int idGenere, string genere)
        {
            IdGenere = idGenere;
            Genre = genere;
        }
    }
}
