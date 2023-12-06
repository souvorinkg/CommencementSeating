using System.ComponentModel.DataAnnotations;

namespace SeatingChart.Models
{
    public class Student
    { 

        public enum Type {
            Bachelor,
            Graduate,
            Faculty
        }
        public int ID { get; set; } 
        [Display(Name ="First Name")]  
        public string FirstName { get; set; }  
        
        [Display(Name = "Middle Name")]
        public string MiddleName {get; set;} 
        
        [Display(Name = "Last Name")] 
         public string LastName { get; set; }    


        [Display(Name = "Please Enter Full Names")]
         public string FullName { get { return FirstName + " " + MiddleName + " " + LastName; } }
        
    }
}
 
    
