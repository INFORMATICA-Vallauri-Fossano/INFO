using AnrangoRamosLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Models
{
    internal class Prestito
    {
        public int IdPrestito { get; set; }
        public int IdLettore { get; set; }
        private string codiceISBN;
        private DateTime dataInizio;
        private DateTime? dataFine;
        public string CodiceISBN
        {
            get => codiceISBN; set
            {
                if (RegexUtilities.IsValidISBN(value)) codiceISBN = value;
                else throw new Exception("codice ISBN non valido");
            }
        }
        public DateTime DataInizio
        {
            get => dataInizio; set
            {
                if (value > DateTime.Now) throw new Exception("Data di inizio non valida");
                dataInizio = value;
            }
        }
        public DateTime? DataFine
        {
            get => dataFine; set
            {
                if (value == null) dataFine = null;
                else
                {
                    if (value < DataInizio) throw new Exception("Data di fine non valida");
                    
                    dataFine = value;
                }
            }
        }
        public Prestito(int _idprestito,int _idlettore,string _isbn, DateTime inizio, DateTime? fine)
        {
            IdPrestito = _idprestito;
            CodiceISBN=_isbn;
            IdLettore = _idlettore;
            DataInizio = inizio;
            DataFine = fine;
        }
        public override string ToString()
        {
            return $"Lettore: {IdLettore} - Libro:{CodiceISBN}";
        }
    }
}
