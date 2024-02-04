using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace SeatingChart.Pages.Students
{
    public class SetNumColumnsModel : PageModel
    {
        private readonly SeatingChart.Data.ChartContext _context;

        public SetNumColumnsModel(SeatingChart.Data.ChartContext context)
        {
            _context = context;
        }

        private bool ConfigExists(int id)
        {
            return _context.Configurations.Any(e => e.ID == id);
        }

        public async Task<IActionResult> OnGetAsync(int? num, int? chartNum)
        {
            if (num == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToPage("./Index", chartNum);
            }
                        
            var conf = from c in _context.Configurations.Where(c => c.ID == chartNum) select c;
            if (await conf.AnyAsync())
            {
                var config = await conf.FirstAsync();

                if (num < 1) num = 1;

                config.NumberofColumns = (int)num;
                _context.Attach(config).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConfigExists(config.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return RedirectToPage("./Index",new{chartNum = chartNum.ToString()});
            }

            return RedirectToPage("./Index",new{chartNum = chartNum.ToString()});
        }
    }
}
