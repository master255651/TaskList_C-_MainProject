using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskList.Application.Common.Exceptions;
using TaskList.Application.Tasks.Commands.DeleteTask;
using TaskList.Application.Tasks.Commands.CreateTask;
using TaskList.Tests.Common;
using Xunit;

namespace TaskList.Tests.Tasks.Commands
{
    public class DeleteTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new DeleteTaskCommandHandler(Context);

            // Act
            await handler.Handle(new DeleteTaskCommand
            {
                Id = TaskListContextFactory.TaskIdForDelete,
                UserId = TaskListContextFactory.UserAId
            }, CancellationToken.None);

            // Assert
            Assert.Null(Context.Tasks.SingleOrDefault(task =>
                task.Id == TaskListContextFactory.TaskIdForDelete));
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new DeleteTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteTaskCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = TaskListContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task DeleteTaskCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var deleteHandler = new DeleteTaskCommandHandler(Context);
            var createHandler = new CreateTaskCommandHandler(Context);
            var taskId = await createHandler.Handle(
                new CreateTaskCommand
                {
                    Title = "TaskTitle",
                    Details = "TaskDetails",
                    UserId = TaskListContextFactory.UserAId
                }, CancellationToken.None);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteTaskCommand
                    {
                        Id = taskId,
                        UserId = TaskListContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
