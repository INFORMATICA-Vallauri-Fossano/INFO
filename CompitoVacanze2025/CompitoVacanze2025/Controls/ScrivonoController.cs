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
    internal class ScrivonoController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True";

        static public List<Scrivono> Read()
        {
            var scritti = new List<Scrivono>();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM scrivono", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var scritto = new Scrivono(
                            reader.GetInt32(0),
                            reader.GetInt32(1), // _idlettore
                            reader.GetString(2) // _codiceISBN
                        );
                        scritti.Add(scritto);
                    }
                }
            }
            return scritti;
        }
    }
}
