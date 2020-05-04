using System;
using System.Data.SqlClient;

namespace ADOClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADOClientDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            string querystring = "Select * from AdoClient";
            conn.Open();
            SqlCommand cmd = new SqlCommand(querystring, conn);
           
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + reader[3].ToString() + reader[4].ToString());
            }

            // Close the connection String
            conn.Close();
        }
    }
}
