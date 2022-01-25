namespace ProiectDAW.Entities
{
    public class Service_AutoClient
    {
        public string Service_AutoId {  get; set; }

        public Service_Auto Service_Auto {  get; set; }
        public string ClientId { get; set; }

        public Client Client {  get; set; }
    }
}
