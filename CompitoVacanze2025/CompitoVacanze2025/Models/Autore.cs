using AnrangoRamosLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Models
{
    internal class Autore
    {
        public int Id{ get; set; }
        private string nome;
        private string cognome;
        public string Nome
        {
            get => nome;
            set
            {
                if (!RegexUtilities.CheckSafeSurname(value, 50)) throw new Exception("Il nome possiede caratteri non consentiti");
                else nome = value;
            }
        }
        public string Cognome
        {
            get => cognome;
            set
            {
                if (!RegexUtilities.CheckSafeSurname(value, 50)) throw new Exception("Il cognome non è valido");
                else cognome = value;
            }
        }
        public Autore(int _id,string _nome,string _cognome)
        {
            Id = _id;
            Nome = _nome;
            Cognome = _cognome;
        }
    }
}
