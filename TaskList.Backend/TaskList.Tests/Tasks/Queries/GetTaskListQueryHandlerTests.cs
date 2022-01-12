using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using TaskList.Application.Tasks.Queries.GetTaskList;
using TaskList.Persistence;
using TaskList.Tests.Common;
using Shouldly;
using Xunit;

namespace TaskList.Tests.Tasks.Queries
{
    [Collection("QueryCollection")]
    public class GetTaskListQueryHandlerTests
    {
        private readonly TaskListDbContext Context;
        private readonly IMapper Mapper;

        public GetTaskListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTaskListQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTaskListQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTaskListQuery
                {
                    UserId = TaskListContextFactory.UserBId
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TaskListVm>();
            result.Tasks.Count.ShouldBe(2);
        }
    }
}
