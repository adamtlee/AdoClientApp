using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADOClientDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            ReadData(conn); 
            // InsertData(conn); 

            // Close the connection String
            conn.Close();
        }

        public static void InsertData(SqlConnection conn)
        {
            // string insertmethod = "INSERT INTO ADOClient (Id, Name, Description, Abbreviation, ClientType) VALUES()"
        }

        public static void ReadData(SqlConnection conn)
        {
            string querystring = "Select * from AdoClient";
            SqlDataAdapter adapter = new SqlDataAdapter(querystring, conn);
            DataSet clientData = new DataSet();
            adapter.Fill(clientData, "AdoClient");
            Console.WriteLine(clientData.GetXml());
            Console.ReadKey();
        }
    }
}
