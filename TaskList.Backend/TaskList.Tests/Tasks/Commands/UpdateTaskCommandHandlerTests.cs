using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskList.Application.Common.Exceptions;
using TaskList.Application.Tasks.Commands.UpdateTask;
using TaskList.Tests.Common;
using Xunit;

namespace TaskList.Tests.Tasks.Commands
{
    public class UpdateTaskCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateTaskCommandHandler_Success()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);
            var updatedTitle = "new title";

            // Act
            await handler.Handle(new UpdateTaskCommand
            {
                Id = TaskListContextFactory.TaskIdForUpdate,
                UserId = TaskListContextFactory.UserBId,
                Title = updatedTitle
            }, CancellationToken.None);

            // Assert
            Assert.NotNull(await Context.Tasks.SingleOrDefaultAsync(task =>
                task.Id == TaskListContextFactory.TaskIdForUpdate &&
                task.Title == updatedTitle));
        }

        [Fact]
        public async Task UpdateTaskCommandHandler_FailOnWrongId()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new UpdateTaskCommand
                    {
                        Id = Guid.NewGuid(),
                        UserId = TaskListContextFactory.UserAId
                    },
                    CancellationToken.None));
        }

        [Fact]
        public async Task UpdateTaskCommandHandler_FailOnWrongUserId()
        {
            // Arrange
            var handler = new UpdateTaskCommandHandler(Context);

            // Act
            // Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(
                    new UpdateTaskCommand
                    {
                        Id = TaskListContextFactory.TaskIdForUpdate,
                        UserId = TaskListContextFactory.UserAId
                    },
                    CancellationToken.None);
            });
        }
    }
}
