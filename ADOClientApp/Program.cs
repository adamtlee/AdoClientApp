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
            adapter.Fill(clientData, "AdoClient");

            CreateClient(adapter, clientData);

            // ReadClient(adapter, clientData); 
             

            // Close the connection String
            conn.Close();
        }

        public static void CreateClient(SqlDataAdapter adapter, DataSet clientData)
        {
            DataRow row = clientData.Tables["AdoClient"].NewRow();
            Console.WriteLine("Creating new Row..");

            Console.Write("[Temp] Insert ID: ");
            row["Id"] = Console.ReadLine();

            Console.WriteLine("Enter The Name of the Client: ");
            row["Name"] = Console.ReadLine();

            Console.WriteLine("Enter the Description: ");
            row["Description"] = Console.ReadLine();

            Console.WriteLine("Enter the Abbreviation: ");
            row["Abbreviation"] = Console.ReadLine();

            Console.WriteLine("Enter the Client Type: ");
            row["ClientType"] = Console.ReadLine();

            clientData.Tables["AdoClient"].Rows.Add(row);

            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            adapter.Update(clientData.Tables["AdoClient"]);

            Console.WriteLine("Client Sucessfully created!");
        }

        public static void ReadClient(SqlDataAdapter adapter, DataSet clientData)
        {              
            Console.WriteLine(clientData.GetXml());
            Console.ReadKey();
        }
    }
}
