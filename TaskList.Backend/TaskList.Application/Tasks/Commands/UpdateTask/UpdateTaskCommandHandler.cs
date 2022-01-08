using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskList.Application.Interfaces;
using TaskList.Application.Common.Exceptions;

namespace TaskList.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskListDbContext _dbContext;

        public UpdateTaskCommandHandler(ITaskListDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Tasks.FirstOrDefaultAsync(task =>
                    task.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Domain.Task), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
