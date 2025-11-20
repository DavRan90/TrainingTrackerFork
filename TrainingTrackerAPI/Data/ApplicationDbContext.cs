using Microsoft.EntityFrameworkCore;
using TrainingTrackerAPI.Models;

namespace TrainingTrackerAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Activity> Activities { get; set; }
    }
}
