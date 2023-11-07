using Microsoft.EntityFrameworkCore;
using TaskThree_TaskList_.Models;

namespace TaskThree_TaskList_.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<TaskListModel> TaskListModels { get; set; }    
    }
}
