using System;
using System.Collections.Generic;
using System.Text;

namespace ADOClientApp.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Abbreviation { get; set; }
        public ClientType ClientType { get; set; }
    }
}
