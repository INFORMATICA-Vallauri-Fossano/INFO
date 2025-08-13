using CompitoVacanze2025.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Controls
{
    internal class PrestitiController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True";

        static public bool Create(Prestito prestito)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("SELECT COUNT(*) FROM LIBRI WHERE _codiceISBN = @isbn AND _idlettore=@lettore and datafine=null", conn))
                {
                    cmd.Parameters.AddWithValue("@isbn", prestito.CodiceISBN);
                    cmd.Parameters.AddWithValue("@lettore", prestito.IdLettore);
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        return false; 
                    }
                    conn.Close();
                }
                using (var cmd = new SqlCommand(@"INSERT INTO PRESTITI (_idlettore,_codiceISBN,datainizio,datafine) values(@lettore,@isbn,@inizio,@fine)", conn))
                {
                    cmd.Parameters.AddWithValue("@lettore", prestito.IdLettore);
                    cmd.Parameters.AddWithValue("@isbn", prestito.CodiceISBN);
                    cmd.Parameters.AddWithValue("@inizio", prestito.DataInizio);
                    cmd.Parameters.AddWithValue("@fine", (object)prestito.DataFine ?? DBNull.Value); // Use DBNull.Value for null

                    conn.Open();
                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
        /// <summary>
        /// Update the end date of a loan, just that. What would you do with the start date? or the reader? or the book?
        /// </summary>
        /// <param name="prestito"></param>
        /// <returns></returns>
        static public bool Update(Prestito prestito)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE PRESTITI SET datafine = @fine WHERE idprestito = @id", conn))
            {
                cmd.Parameters.AddWithValue("@fine", prestito.DataFine);
                cmd.Parameters.AddWithValue("@id", prestito.IdPrestito);
                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

    }
}
