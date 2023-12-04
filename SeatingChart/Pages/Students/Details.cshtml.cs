using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeatingChart.Data;
using SeatingChart.Models;

namespace SeatingChart.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly SeatingChart.Data.ChartContext _context;

        public DetailsModel(SeatingChart.Data.ChartContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) {
                return NotFound();
            }
            
            //TODO: Set database stuff
            
            return RedirectToPage("./Index");
            
            if (id == null)
            { 
                
                return NotFound();
            }

            var student = await _context.Students.FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
