using System.Collections.Generic;

namespace ProiectDAW.Entities
{
    public class Service_Auto
    {
        public string Id { get; set; }

        public string Name {  get; set; }

        public ServiceAutoAdress ServiceAutoAdress {  get; set; }

        public ICollection <Employee> Employees {  get; set;}

        public ICollection <Service_AutoClient> Service_AutoClients {  get; set; }
    }
}
