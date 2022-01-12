using System;
using Microsoft.EntityFrameworkCore;
using TaskList.Persistence;

namespace TaskList.Tests.Common
{
    public class TaskListContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid TaskIdForDelete = Guid.NewGuid();
        public static Guid TaskIdForUpdate = Guid.NewGuid();

        public static TaskListDbContext Create()
        {
            var options = new DbContextOptionsBuilder<TaskListDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new TaskListDbContext(options);
            context.Database.EnsureCreated();
            context.Tasks.AddRange(
                new Domain.Task
                {
                    CreationDate = DateTime.Today,
                    Details = "Details1",
                    EditDate = null,
                    Id = Guid.Parse("87FD6C5E-EE5C-4311-8C2B-6FF7C420C578"),
                    Title = "Title1",
                    UserId = UserAId
                },
                new Domain.Task
                {
                    CreationDate = DateTime.Today,
                    Details = "Details2",
                    EditDate = null,
                    Id = Guid.Parse("ECEB8814-B818-451D-9DBD-B07B991F5EC1"),
                    Title = "Title2",
                    UserId = UserBId
                },
                new Domain.Task
                {
                    CreationDate = DateTime.Today,
                    Details = "Details3",
                    EditDate = null,
                    Id = TaskIdForDelete,
                    Title = "Title3",
                    UserId = UserAId
                },
                new Domain.Task
                {
                    CreationDate = DateTime.Today,
                    Details = "Details4",
                    EditDate = null,
                    Id = TaskIdForUpdate,
                    Title = "Title4",
                    UserId = UserBId
                }
            );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(TaskListDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
