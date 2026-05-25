using Microsoft.EntityFrameworkCore;
using Project08_TodoDatabaseStore.Models;

namespace Project08_TodoDatabaseStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<TodoTask> TodoTasks { get; set; }
    }
}