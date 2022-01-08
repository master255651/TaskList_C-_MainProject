using MediatR;
using TaskList.Application.Interfaces;
using TaskList.Application.Common.Exceptions;

namespace TaskList.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler
        : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskListDbContext _dbContext;

        public DeleteTaskCommandHandler(ITaskListDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }

            _dbContext.Tasks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
