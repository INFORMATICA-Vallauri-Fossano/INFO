using AnrangoRamosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Models
{
    internal class Scrivono
    {
        public int Id { get; set; }
        public int IdAutore { get; set; }
        private string codiceISBN;

        public string CodiceISBN { get=>codiceISBN; set
            {
                if (RegexUtilities.IsValidISBN(value)) codiceISBN = value;
                else throw new Exception("codice ISBN non valido");
            }
        }
        public Scrivono(int _id, int  _idAutore,string _isbn)
        {
            Id = _id;
            IdAutore = _idAutore;
            CodiceISBN = _isbn;
        }
    }
}
