using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskList.Application.Interfaces;

namespace TaskList.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler
        : IRequestHandler<GetTaskListQuery, TaskListVm>
    {
        private readonly ITaskListDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(ITaskListDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskListVm> Handle(GetTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var tasksQuery = await _dbContext.Tasks
                .Where(task => task.UserId == request.UserId)
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListVm { Tasks = tasksQuery };
        }
    }
}
