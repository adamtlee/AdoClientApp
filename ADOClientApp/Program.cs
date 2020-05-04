using ADOClientApp.Models;
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

        menu:
            Console.WriteLine("Welcome to the client App. ");
            Console.Write(
                "Enter the following commands to perform Crud operations" + "\n" +
                "Enter c to create a new client" + "\n" +
                "Enter r to read the client list" + "\n" +
                "Enter z to read an client by Id" + "\n" +
                "Enter u to update a client" + "\n" +
                "Enter d to delete a client" + "\n");

            string userInput = Console.ReadLine().ToLower();
            switch (userInput)
            {
                case "c":
                    CreateClient(adapter, clientData);
                    goto menu;
                case "r":
                    ReadClient(adapter, clientData);
                    goto menu;
                case "z":
                    ReadClientById(adapter, clientData);
                    goto menu;
                case "u":
                    UpdateClient(adapter, clientData);
                    goto menu;
                case "d":
                    DeleteClient(adapter, clientData);
                    goto menu;
                default:
                    Console.WriteLine("Incorrect Input");
                    break;

            }

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

        private static void ReadClientById(SqlDataAdapter adapter, DataSet clientData)
        {
            // SqlCommand cmd = new SqlCommand(adapter, clientData);
            // SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("ReadClientById");
            Console.WriteLine("Enter the Id of the Client: ");
            string input = Console.ReadLine();

            int i = Convert.ToInt32(input);
            Console.WriteLine(i);
            //= clientData.Tables["AdoClient"].Rows[i]["Name"]; 

        }

        public static void UpdateClient(SqlDataAdapter adapter, DataSet clientData)
        {
            Console.WriteLine("Update Method");
        }

        private static void DeleteClient(SqlDataAdapter adapter, DataSet clientData)
        {
            Console.WriteLine("Delete Method");
        }
    }
}
