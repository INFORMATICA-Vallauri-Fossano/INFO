using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CompitoVacanze2025.Models;
namespace CompitoVacanze2025.Controls
{
    internal class queryController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True";
        public static DataTable quattro()
        {
            DataTable migliori = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 L.cognome,l.nome,count(P.idPrestito) as 'prestiti' FROM LETTORI L RIGHT JOIN PRESTITI P ON L.idLettore=P._idLettore\r\ngroup by L.cognome,l.nome\r\norder by count(P.idPrestito) desc", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(migliori);
                    }
                }

            }
            return migliori;
        }

        internal static List<Lettore> cinque()
        {
            List<Lettore> ritardatari = new List<Lettore>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT l.idLettore,l.cognome,l.nome,l.email,l.telefono FROM PRESTITI P left JOIN LETTORI L ON P._idLettore=L.idLettore \r\nWHERE DATEDIFF(DAY,P.dataInizio,GETDATE())>30\r\ngroup by l.idLettore,l.cognome,l.nome,l.email,l.telefono", conn))
                {
                    var r = cmd.ExecuteReader();
                    while (r.Read())
                        ritardatari.Add(new Lettore(
                            r.GetInt32(r.GetOrdinal("idLettore")),
                            r.GetString(r.GetOrdinal("nome")),
                            r.GetString(r.GetOrdinal("cognome")),
                            r.GetString(r.GetOrdinal("email")),
                            r.GetString(r.GetOrdinal("telefono"))
                            ));
                }
            }


            return ritardatari;
        }
        internal static int sei()
        {
            int giorni = -1;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT AVG(DATEDIFF(DAY,DATAINIZIO,DATAFINE)) FROM PRESTITI", conn))
                {
                    giorni = (int)cmd.ExecuteScalar();
                }
            }
            return giorni;
        }

        internal static DataTable sette()
        {
            DataTable inprestito = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT P.DATAINIZIO,L.TITOLO FROM PRESTITI P LEFT JOIN LIBRI L ON P._CODICEISBN=L.CODICEISBN WHERE DATAFINE is NULL ORDER BY P.DATAINIZIO,L.TITOLO", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(inprestito);
                    }
                }
                return inprestito;
            }
        }

        internal static DataTable otto()
        {
            DataTable prestitiMeseAnno = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT YEAR(DATAINIZIO) AS 'ANNO'\r\n,sum(iif(month(datainizio)=1,1,0)) as 'Gennaio'\r\n,sum(iif(month(datainizio)=2,1,0)) as 'Febbraio'\r\n,sum(iif(month(datainizio)=3,1,0)) as 'Marzo'\r\n,sum(iif(month(datainizio)=4,1,0)) as 'Aprile'\r\n,sum(iif(month(datainizio)=5,1,0)) as 'Maggio'\r\n,sum(iif(month(datainizio)=6,1,0)) as 'Giugno'\r\n,sum(iif(month(datainizio)=7,1,0)) as 'Luglio'\r\n,sum(iif(month(datainizio)=8,1,0)) as 'Agosto'\r\n,sum(iif(month(datainizio)=9,1,0)) as 'Settembre'\r\n,sum(iif(month(datainizio)=10,1,0)) as 'Ottobre'\r\n,sum(iif(month(datainizio)=11,1,0)) as 'Novembre'\r\n,sum(iif(month(datainizio)=12,1,0)) as 'Dicembre'\r\n,count(*) as 'Totale'FROM PRESTITI\r\nGROUP BY YEAR(DATAINIZIO) ", conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(prestitiMeseAnno);
                    }
                }
            }
            return prestitiMeseAnno;
        }

        internal static int nove(DateTime inizio, DateTime fine)
        {
            int nPrestiti = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM PRESTITI WHERE DATAINIZIO >= @inizio AND DATAINIZIO <= @fine", conn))
                {
                    cmd.Parameters.AddWithValue("@inizio", inizio);
                    cmd.Parameters.AddWithValue("@fine", fine);
                    conn.Open();
                    nPrestiti = (int)cmd.ExecuteScalar();
                }
            }
                return nPrestiti;
        }
    }
}
