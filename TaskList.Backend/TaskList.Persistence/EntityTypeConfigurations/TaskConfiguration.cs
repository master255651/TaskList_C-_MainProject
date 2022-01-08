using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskList.Persistence.EntityTypeConfigurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Domain.Task>
    {
        public void Configure(EntityTypeBuilder<Domain.Task> builder)
        {
            builder.HasKey(task => task.Id);
            builder.HasIndex(task => task.Id).IsUnique();
            builder.Property(task => task.Title).HasMaxLength(250);
        }
    }
}