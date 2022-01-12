using AutoMapper;
using System;
using TaskList.Application.Interfaces;
using TaskList.Application.Common.Mappings;
using TaskList.Persistence;
using Xunit;

namespace TaskList.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public TaskListDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = TaskListContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(ITaskListDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            TaskListContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
