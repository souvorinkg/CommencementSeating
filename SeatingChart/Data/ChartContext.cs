using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SeatingChart.Models;

namespace SeatingChart.Data
{
    public class ChartContext : DbContext
    {
        public ChartContext (DbContextOptions<ChartContext> options)
            : base(options)
        {
        } 
        public DbSet<Student> Students { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
        }

        public DbSet<SeatingChart.Models.Student> Student { get; set; } = default!;
    }
}
