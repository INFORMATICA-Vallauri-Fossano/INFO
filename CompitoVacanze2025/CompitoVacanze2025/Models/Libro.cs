using AnrangoRamosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Models
{
    internal class Libro
    {
        private string codiceISBN;
        private string titolo;
        private int numeroPagine;
        private string lingua;
        private DateTime dataPubblicazzione;
        private string collocazione;
        private string copertina;
        private string casaEditrice;
        public bool Disponibile;
        public int _IdGenere { get; set; }

            public Libro(
                string _codiceISBN,
                string _titolo,
                string _numeroPagine,string _lingua,
                string _dataPubblicazione,
                string _collocazione,
                string _copertina,
                string _casaEditrice,
                bool _disponibile,
                int IdGenere)
            {
                CodiceISBN = _codiceISBN;
                Titolo = _titolo;
                NumeroPagine = _numeroPagine;
                Lingua = _lingua;
                DataPubblicazione = _dataPubblicazione;
                Collocazione = _collocazione;
                Copertina = _copertina;
                CasaEditrice = _casaEditrice;
                Disponibile = _disponibile;
                _IdGenere = IdGenere;
            }

        public string CodiceISBN { get => codiceISBN;set
            {
                if (RegexUtilities.IsValidISBN(value)) codiceISBN = value;
                else throw new Exception("codice ISBN non valido");
            }
        }
        public string Titolo { get => titolo; set { 
                if(RegexUtilities.CheckSafeTitle(value,200)) titolo = value;

            } }
        public string NumeroPagine
        {
            get => numeroPagine.ToString();
            set
            {
                numeroPagine=RegexUtilities.ToPositiveInt(value);
                if (numeroPagine < 1) throw new Exception("Il numero di pagine deve essere maggiore di zero");
            }
        }
        public string DataPubblicazione
        {
            get=> dataPubblicazzione.ToShortDateString();
            set {
                DateTime dataParsata;
                try
                {
                    dataParsata= DateTime.Parse(value);
                }
                catch (Exception)
                {
                    throw new Exception("Il formato della data non è valido: errore nel parsing");
                }
                if (dataParsata > DateTime.Now) throw new Exception("La data non può essere nel futuro");
                else dataPubblicazzione = dataParsata;
            }
        }
        public string Collocazione
        {
            get=> collocazione; set
            {
                if (Regex.IsMatch(value, @"^\w\d\d$")) collocazione = value;
                else throw new Exception("La collocazione non è valida [ala:char][scaffale:int][piano:int]");
            }
        }
        public string Copertina
        {
            get => copertina;
            set
            {
                if(RegexUtilities.CheckAuthorizedPath(value, ""))
                    copertina = value;
            }
        }
        public string CasaEditrice
        {
            get => casaEditrice;
            set
            {
                if(RegexUtilities.CheckSafeTitle(value,50)) casaEditrice = value;
            }
        }
        public string Lingua
        {
            get => lingua;
            set
            {
                if (!RegexUtilities.CheckSafeTitle(value,50)) lingua = value;
            }
        }
        public override string ToString()
        {
            return $"{CodiceISBN} - {Titolo} - {NumeroPagine} pagine - {DataPubblicazione} - {Collocazione} - {Copertina} - {CasaEditrice} - Disponibile: {Disponibile}";
        }
    }
}
