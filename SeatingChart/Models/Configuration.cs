using System.ComponentModel.DataAnnotations;
using Microsoft.CodeAnalysis.Scripting;

namespace SeatingChart.Models
{ 
    public class Configuration { 
        int ID { get; set; }
        int NumberofColumns { get; set; } 
        
    }
}