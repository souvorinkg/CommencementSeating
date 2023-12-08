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
        public String namesInput { get; set; } = default!;

        [BindProperty]
        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            // Check if namesInput is not empty
            if (!string.IsNullOrWhiteSpace(namesInput))
            {
                // Split the input into an array of names 
                Console.Write(namesInput);
                string[] namesArray = namesInput.Split('\n', StringSplitOptions.RemoveEmptyEntries);

                foreach (var name in namesArray)
                {
                    var nameParts = name.Trim().Split(' ');

                    var newStudent = new Student
                    {
                        FirstName = nameParts[0],

                        MiddleName = nameParts.Length >= 3
                            ? nameParts.Skip(1).Take(nameParts.Length - 2).Aggregate((x, y) => x + " " + y)
                            : "",

                        LastName = nameParts.Length >= 2
                            ? nameParts.Last()
                            : ""
                    };

                    _context.Students.Add(newStudent);
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Handle case where namesInput is empty
            ModelState.AddModelError("namesInput", "Please provide a list of names.");
            return Page();
        }
    }
}
