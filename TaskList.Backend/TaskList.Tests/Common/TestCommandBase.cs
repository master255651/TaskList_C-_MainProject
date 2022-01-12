using System;
using TaskList.Persistence;

namespace TaskList.Tests.Common
{
    public abstract  class TestCommandBase : IDisposable
    {
        protected readonly TaskListDbContext Context;

        public TestCommandBase()
        {
            Context = TaskListContextFactory.Create();
        }

        public void Dispose()
        {
            TaskListContextFactory.Destroy(Context);
        }
    }
}
