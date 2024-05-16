using Microsoft.EntityFrameworkCore;

namespace ReportProject.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext>options) : base(options)
        {
            
        }
        public DbSet<Employees> Employees { get; set; }

    }
}
