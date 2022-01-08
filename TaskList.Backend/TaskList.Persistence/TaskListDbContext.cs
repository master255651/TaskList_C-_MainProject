using Microsoft.EntityFrameworkCore;
using TaskList.Application.Interfaces;
using TaskList.Persistence.EntityTypeConfigurations;

namespace TaskList.Persistence
{
    public class TaskListDbContext : DbContext, ITaskListDbContext
    {
        public DbSet<Domain.Task> Tasks { get; set; }

        public TaskListDbContext(DbContextOptions<TaskListDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
