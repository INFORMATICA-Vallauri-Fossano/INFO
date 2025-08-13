using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Controls
{
    internal class AutoriController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True";
        static public Dictionary<int, string> Read()
        {
            Dictionary<int, string> autori = new Dictionary<int, string>();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM AUTORI", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        autori.Add(Convert.ToInt32(reader["idAutore"]), reader["cognome"].ToString()+reader["nome"].ToString());
                    }
                }
            }
            return autori;
        }
    }
}
