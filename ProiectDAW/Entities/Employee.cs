namespace ProiectDAW.Entities
{
    public class Employee
    {
        public string Id {  get; set; }

        public string FirstName {  get; set; }

        public string LastName { get; set; }

        public string Position {  get; set; }

        public Service_Auto Service_Auto {  get; set; }
    }
}
