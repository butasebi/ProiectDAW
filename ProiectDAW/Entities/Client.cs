using System;
using System.Collections.Generic;

namespace ProiectDAW.Entities
{
    public class Client
    {
        public string Id {  get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime RegisterDay { get; set; }

        public ICollection<Service_AutoClient> Service_AutoClients { get; set; }
    }
}
