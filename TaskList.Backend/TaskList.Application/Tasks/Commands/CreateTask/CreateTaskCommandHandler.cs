using MediatR;
using TaskList.Application.Interfaces;

namespace TaskList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITaskListDbContext _dbContext;

        public CreateTaskCommandHandler(ITaskListDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = new Domain.Task
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await _dbContext.Tasks.AddAsync(task, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return task.Id;
        }
    }
}
