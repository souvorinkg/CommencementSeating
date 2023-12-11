using SeatingChart.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using SeatingChart.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace SeatingChart.Pages.Students
{
    public class DeleteAllModel : PageModel
    {
        private readonly SeatingChart.Data.ChartContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteAllModel(SeatingChart.Data.ChartContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Delete All failed. Try again";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                _context.Students.RemoveRange(_context.Students);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./DeleteAll",
                                     new {  saveChangesError = true });
            }
        }
    }
}