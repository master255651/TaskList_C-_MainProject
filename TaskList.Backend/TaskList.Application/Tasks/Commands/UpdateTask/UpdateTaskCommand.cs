using MediatR;

namespace TaskList.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}
