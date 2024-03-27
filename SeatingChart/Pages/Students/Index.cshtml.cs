using SeatingChart.Data;
using SeatingChart.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using SeatingChart;

namespace SeatingChart.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly ChartContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ChartContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }
        public int ChartNum {get;set;}
        public string NameSort { get; set; }

        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        //  public PaginatedList<Student> Students { get; set; } 

        public List<Student> Students { get; set; }

        public int numCols { get; set;}

        public async Task OnGetAsync(int chartNum, string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            ChartNum = chartNum;
            Console.WriteLine("ccc");
            Console.WriteLine(chartNum);
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
    
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName + " " + s.FirstName + " " + s.MiddleName); 
            
                    break;
            } 
        
            var conf = from c in _context.Configurations.Where(c => c.ID == ChartNum) select c;
            numCols = 2;
            if(await conf.AnyAsync()) {
                numCols = (await conf.FirstAsync()).NumberofColumns;
            }

            // var pageSize = Configuration.GetValue("PageSize", 4);
            // Students = await PaginatedList<Student>.CreateAsync(
                // studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            Students = studentsIQ.ToList();
        }
    }
}