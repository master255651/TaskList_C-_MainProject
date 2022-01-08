using AutoMapper;
using TaskList.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskList.Application.Common.Exceptions;


namespace TaskList.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryHandler
         : IRequestHandler<GetTaskDetailsQuery, TaskDetailsVm>
    {
        private readonly ITaskListDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(ITaskListDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskDetailsVm> Handle(GetTaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks
                .FirstOrDefaultAsync(task =>
                task.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Domain.Task), request.Id);
            }

            return _mapper.Map<TaskDetailsVm>(entity);
        }
    }
}
