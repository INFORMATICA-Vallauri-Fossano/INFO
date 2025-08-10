using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompitoVacanze2025.Controls
{
    internal class GeneriController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True";
        static public Dictionary<int, string> Read()
        {
            Dictionary<int, string> generi=new Dictionary<int, string>();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM GENERI", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        generi.Add(Convert.ToInt32(reader["idGenere"]), reader["genere"].ToString());
                    }
                }
            }
            return generi;
        }
        static public int[] ReadId()
        {
            List<int> idGeneri = new List<int>();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM GENERI", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idGeneri.Add(Convert.ToInt32(reader["idGenere"]));
                    }
                }
            }
            return idGeneri.ToArray();
        }
    }
}
