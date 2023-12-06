using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SeatingChart.Data;
using SeatingChart.Models;

namespace SeatingChart.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly SeatingChart.Data.ChartContext _context;

        public CreateModel(SeatingChart.Data.ChartContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;

        
        public async Task<IActionResult> OnPostAsync()
        {
            
            
            
            var emptyStudent = new Student();

            if (await TryUpdateModelAsync<Student>(
                emptyStudent,
                "student",   // Prefix for form value.
                s => s.FirstName, s => s.MiddleName, s => s.LastName))
            {
                _context.Students.Add(emptyStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
