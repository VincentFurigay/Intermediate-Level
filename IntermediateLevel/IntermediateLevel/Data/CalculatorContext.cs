using IntermediateLevel.Models;
using Microsoft.EntityFrameworkCore;

namespace IntermediateLevel.Data
{
    public class CalculatorContext : DbContext
    {
        public CalculatorContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TimeAttendance> TimeAttendances { get; set; }
        public DbSet<Payreg> Payregs { get; set; }
    }
}
