namespace SeatingChart.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string LastName { get; set; } 
        public string MiddleName {get; set;}
        public string FirstName { get; set; }

        public string FullName {
            get {
                return FirstName + MiddleName.Substring(0, 1) + LastName;
            }
        }

      
    }
}