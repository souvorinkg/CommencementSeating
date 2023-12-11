using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Scripting;

namespace SeatingChart.Models
{ 
    public class Configuration { 
        public int ID { get; set; }
    
        [Display(Name ="Number Of Columns")]
        public int NumberofColumns { get; set; } 
    }
}