namespace SeatingChart.Models
{
    public class Student
    { 

        public enum Type {
            Bachelor,
            Graduate,
            Empty,
            Faculty
        }
        public int ID { get; set; }
        public string FirstName { get; set; }  
        
        public string MiddleName {get; set;}
        public string LastName { get; set; }

    }
}