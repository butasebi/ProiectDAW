namespace ProiectDAW.Entities
{
    public class ServiceAutoAdress
    {
        public string Id {  get; set; }

        public string Service_AutoId { get; set; }

        public string Street_name {  get; set; }

        public string City { get; set; }

        public string Country {  get; set; }

        public Service_Auto Service_Auto { get; set; }

    }
}
