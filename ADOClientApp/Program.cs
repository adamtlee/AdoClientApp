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
            string query = "Select * from AdoClient";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            conn.Open();
            DataSet clientData = new DataSet();
           //CreateData(adapter, clientData);
            ReadData(adapter, clientData); 
             

            // Close the connection String
            conn.Close();
        }

        public static void CreateData(SqlDataAdapter adapter, DataSet clientData)
        {
           

        }

        public static void ReadData(SqlDataAdapter adapter, DataSet clientData)
        {              
            adapter.Fill(clientData, "AdoClient");
            Console.WriteLine(clientData.GetXml());
            Console.ReadKey();
        }
    }
}
