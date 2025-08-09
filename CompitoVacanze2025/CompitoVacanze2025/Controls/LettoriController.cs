using AnrangoRamosLibrary;
using CompitoVacanze2025.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CompitoVacanze2025.Controls
{
    internal class LettoriController
    {
        static string dbName = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).Parent.Parent.FullName.ToString() + @"\App_Data\dbBOOKS.mdf";

        private readonly static string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + dbName + ";Integrated Security=True";
        // CREATE
        static public bool Create(Lettore lettore)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"INSERT INTO LETTORI (nome, cognome, email, telefono)
                                              VALUES (@nome, @cognome, @email, @telefono)", conn))
            {
                cmd.Parameters.AddWithValue("@nome", lettore.Nome);
                cmd.Parameters.AddWithValue("@cognome", lettore.Cognome);
                cmd.Parameters.AddWithValue("@email", lettore.Email);
                cmd.Parameters.AddWithValue("@telefono", lettore.Telefono);

                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        // READ
        static public Lettore Read(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM LETTORI WHERE idLettore = @idLettore", conn))
            {
                cmd.Parameters.AddWithValue("@idLettore", id);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lettore(
                            id,
                            reader["nome"].ToString(),
                            reader["cognome"].ToString(),
                            reader["email"].ToString(),
                            reader["telefono"].ToString()
                        );
                    }
                }
            }
            return null;
        }
        static public List<Lettore> Read()
        {
            List<Lettore> lettori = new List<Lettore>();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("SELECT * FROM LETTORI", conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lettori.Add(new Lettore(
                            Convert.ToInt32(reader["idLettore"]),
                            reader["nome"].ToString(),
                            reader["cognome"].ToString(),
                            reader["email"].ToString(),
                            reader["telefono"].ToString()
                        ));
                    }
                }
            }
            return lettori;
        }

        // UPDATE
        static public bool Update(Lettore lettore)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(@"UPDATE LETTORI SET nome=@nome, cognome=@cognome, telefono=@telefono
                                              ,email=@email WHERE idLettore=@idLettore", conn))
            {
                cmd.Parameters.AddWithValue("@nome", lettore.Nome);
                cmd.Parameters.AddWithValue("@cognome", lettore.Cognome);
                cmd.Parameters.AddWithValue("@telefono", lettore.Telefono);
                cmd.Parameters.AddWithValue("@email", lettore.Email);
                cmd.Parameters.AddWithValue("@idLettore", lettore.IdLettore); 

                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }

        // DELETE
        public static bool Delete(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand("DELETE FROM LETTORI WHERE idLettore = @idLettore", conn))
            {
                cmd.Parameters.AddWithValue("@idLettore", id);
                conn.Open();
                return cmd.ExecuteNonQuery() == 1;
            }
        }
    }
}
