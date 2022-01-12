using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskList.Application.Tasks.Queries.GetTaskDetails;
using TaskList.Persistence;
using TaskList.Tests.Common;
using Shouldly;
using Xunit;

namespace TaskList.Tests.Tasks.Queries
{
    [Collection("QueryCollection")]
    public class GetTaskDetailsQueryHandlerTests
    {
        private readonly TaskListDbContext Context;
        private readonly IMapper Mapper;

        public GetTaskDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetTaskDetailsQueryHandler_Success()
        {
            // Arrange
            var handler = new GetTaskDetailsQueryHandler(Context, Mapper);

            // Act
            var result = await handler.Handle(
                new GetTaskDetailsQuery
                {
                    UserId = TaskListContextFactory.UserBId,
                    Id = Guid.Parse("ECEB8814-B818-451D-9DBD-B07B991F5EC1")
                },
                CancellationToken.None);

            // Assert
            result.ShouldBeOfType<TaskDetailsVm>();
            result.Title.ShouldBe("Title2");
            result.CreationDate.ShouldBe(DateTime.Today);
        }
    }
}
