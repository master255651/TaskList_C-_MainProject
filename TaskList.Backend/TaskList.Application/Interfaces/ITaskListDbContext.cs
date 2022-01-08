using Microsoft.EntityFrameworkCore;

namespace TaskList.Application.Interfaces
{
    public interface ITaskListDbContext
    {
        DbSet<Domain.Task> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
