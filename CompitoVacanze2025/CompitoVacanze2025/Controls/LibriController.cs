using CompitoVacanze2025.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CompitoVacanze2025.Controls
{
    internal class LibriController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="+dbName+";Integrated Security=True";

        // CREATE
        /// <summary>
        /// the creation of a book supposes that it is automatically diponible
        /// 
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        static public bool Create(Libro libro)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO LIBRI (codiceISBN, titolo, numeroPagine, dataPubblicazione, collocazione, copertina, casaEditrice,_idGenere)
                                              VALUES (@isbn, @titolo, @pagine, @data, @collocazione, @copertina, @editrice, @_idGenere)", conn))
            {
                cmd.Parameters.AddWithValue("@isbn", libro.CodiceISBN);
                cmd.Parameters.AddWithValue("@titolo", libro.Titolo);
                cmd.Parameters.AddWithValue("@pagine", libro.NumeroPagine);
                cmd.Parameters.AddWithValue("@data", libro.DataPubblicazione);
                cmd.Parameters.AddWithValue("@collocazione", libro.Collocazione);
                cmd.Parameters.AddWithValue("@copertina", libro.Copertina);
                cmd.Parameters.AddWithValue("@editrice", libro.CasaEditrice);
                cmd.Parameters.AddWithValue("@_idGenere", libro._IdGenere);

                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        // READ
        static public Libro Read(string codiceISBN)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM LIBRI WHERE codiceISBN = @isbn", conn))
            {
                cmd.Parameters.AddWithValue("@isbn", codiceISBN);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Libro(
                            reader["codiceISBN"].ToString(),
                            reader["titolo"].ToString(),
                            reader["numeroPagine"].ToString(),
                            Convert.ToDateTime(reader["dataPubblicazione"]).ToShortDateString(),
                            reader["collocazione"].ToString(),
                            reader["copertina"].ToString(),
                            reader["casaEditrice"].ToString(),
                            Convert.ToBoolean(reader["disponibile"]),
                            Convert.ToInt32(reader["_idGenere"])
                        );
                    }
                }
            }
            return null;
        }
        static public DataTable Read()
        {
            DataTable libriTable = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM LIBRI", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    libriTable.Load(reader);
                }
            }
            return libriTable;
        }

        // UPDATE
        public static bool Update(Libro libro)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE LIBRI SET titolo=@titolo, numeroPagine=@pagine, dataPubblicazione=@data, collocazione=@collocazione, copertina=@copertina, casaEditrice=@editrice, disponibile=@disponibile, _idGenere=@_idGenere
                                              WHERE codiceISBN=@isbn", conn))
            {
                cmd.Parameters.AddWithValue("@isbn", libro.CodiceISBN);
                cmd.Parameters.AddWithValue("@titolo", libro.Titolo);
                cmd.Parameters.AddWithValue("@pagine", libro.NumeroPagine);
                cmd.Parameters.AddWithValue("@data", libro.DataPubblicazione);
                cmd.Parameters.AddWithValue("@collocazione", libro.Collocazione);
                cmd.Parameters.AddWithValue("@copertina", libro.Copertina);
                cmd.Parameters.AddWithValue("@editrice", libro.CasaEditrice);
                cmd.Parameters.AddWithValue("@disponibile", libro.Disponibile);
                cmd.Parameters.AddWithValue("@_idGenere", libro._IdGenere);

                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
        public static bool UpdateDisponibilita(string codiceISBN, bool disponibile)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("UPDATE LIBRI SET disponibile = @disponibile WHERE codiceISBN = @isbn", conn))
            {
                cmd.Parameters.AddWithValue("@isbn", codiceISBN);
                cmd.Parameters.AddWithValue("@disponibile", disponibile);
                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        // DELETE
        public static bool Delete(string codiceISBN)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("DELETE FROM LIBRI WHERE codiceISBN = @isbn", conn))
            {
                cmd.Parameters.AddWithValue("@isbn", codiceISBN);
                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
