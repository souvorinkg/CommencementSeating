using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SeatingChart.Data;
using SeatingChart.Models;

namespace SeatingChart.Pages.PrimaryChart
{
    public class IndexModel : PageModel
{
    private readonly ChartContext _context;
    public IndexModel(ChartContext context)
    {
        _context = context;
    }


    public IList<Student> Students { get; set; }

    public async Task OnGetAsync(string sortOrder)
    {
        // using System;

        IQueryable<Student> studentsIQ = from s in _context.Students
                                        select s;

        Students = await studentsIQ.AsNoTracking().ToListAsync();
    }
}
}
