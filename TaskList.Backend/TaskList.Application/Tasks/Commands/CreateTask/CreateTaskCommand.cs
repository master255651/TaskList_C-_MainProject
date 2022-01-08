using MediatR;

namespace TaskList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
