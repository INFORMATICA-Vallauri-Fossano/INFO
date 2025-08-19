using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompitoVacanze2025.Models;
namespace CompitoVacanze2025.Controls
{
    internal class AutoriController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True";
        static public List<Autore> Read()
        {
            List<Autore> autori = new List<Autore>();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM autori", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        autori.Add(new Autore(
                            Convert.ToInt32(reader["idAutore"]),
                            reader["nome"].ToString(),
                            reader["cognome"].ToString()
                        ));
                    }
                }
            }
            return autori;
        }
    }
}
