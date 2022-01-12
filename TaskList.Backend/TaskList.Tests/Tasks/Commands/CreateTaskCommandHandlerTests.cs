using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskList.Application.Tasks.Commands.CreateTask;
using TaskList.Tests.Common;
using Xunit;

namespace TaskList.Tests.Tasks.Commands
{
    public class CreateTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new CreateTaskCommandHandler(Context);
            var taskName = "task name";
            var taskDetails = "task details";

            // Act
            var taskId = await handler.Handle(
                new CreateTaskCommand
                {
                    Title = taskName,
                    Details = taskDetails,
                    UserId = TaskListContextFactory.UserAId
                },
                CancellationToken.None);

            // Assert
            Assert.NotNull(
                await Context.Tasks.SingleOrDefaultAsync(task =>
                    task.Id == taskId && task.Title == taskName &&
                    task.Details == taskDetails));
        }
    }
}
