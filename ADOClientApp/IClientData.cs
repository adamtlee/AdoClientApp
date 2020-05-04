using ADOClientApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ADOClientApp.Data
{
    public interface IClientData
    {
        IEnumerable<Client> GetAll();
    }

    public class InMemoryClientData : IClientData
    {
        readonly List<Client> clients;
        public InMemoryClientData()
        {
            clients = new List<Client>()
            {
                new Client
                {
                    Id = 1,
                    Name = "Batman",
                    Description = "He's a Bat",
                    Abbreviation = "Batty",
                    ClientType = ClientType.DC
                },

                new Client
                {
                    Id = 2,
                    Name = "Spiderman",
                    Description = "He's a Spier",
                    Abbreviation = "Spidey",
                    ClientType = ClientType.Marvel
                },
                new Client
                {
                    Id = 3,
                    Name = "HarryPotter",
                    Description = "He's a Wizrd",
                    Abbreviation = "Harry",
                    ClientType = ClientType.Wizard
                }

            };
        }
        
        public IEnumerable<Client> GetAll()
        {
            return from c in clients
                   orderby c.Name
                   select c;
        }
    }
}
