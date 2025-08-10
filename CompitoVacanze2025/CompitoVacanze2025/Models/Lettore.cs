using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnrangoRamosLibrary;
namespace CompitoVacanze2025.Models
{
    internal class Lettore
    {
        public Lettore(int _idLettore,string _nome, string _cognome, string _email, string _telefono)
        {
            IdLettore = _idLettore;
            Nome = _nome;
            Cognome = _cognome;
            Email = _email;
            Telefono = _telefono;
        }
        public int IdLettore { get; }
        private string nome;
        public string Nome { get => nome;
            set
            {
                if(RegexUtilities.IsSafeIdentifier(value)) nome = value;
                else throw new Exception("Nome non valido in questo sistema");
            }
        }
        private string cognome;
        public string Cognome
        {
            get => cognome;
            set
            {
                if (RegexUtilities.CheckSafeSurname(value,50)) cognome = value;
                else throw new Exception("Cognome non valido in questo sistema");
            }
        }
        private string email;
        private string telefono="no phone number given";

        public string Email { get=>email;
            set { 
                if(!RegexUtilities.IsValidEmail(value)) throw new Exception("Email non valida");
                else email = value;
            }
        }
        public string Telefono
        {
            get => telefono;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) telefono = "";
                else
                if (!AnrangoRamosLibrary.RegexUtilities.IsValidPhoneNumber(value)) throw new Exception("Numero di telefono non valido");
                else telefono = value;
            }
        }

        public override string ToString()
        {
            return $"Id: {IdLettore} - {Nome} {Cognome} - Email: {Email}, Telefono: {Telefono}";
        }
    }
}
