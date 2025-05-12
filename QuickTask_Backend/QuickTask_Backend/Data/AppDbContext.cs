using Microsoft.EntityFrameworkCore;
using QuickTask_Backend.Models;

namespace QuickTask_Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> TaskItems => Set<TaskItem>();
    }
}
