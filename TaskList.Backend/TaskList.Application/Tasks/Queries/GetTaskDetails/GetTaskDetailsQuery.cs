using MediatR;

namespace TaskList.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQuery : IRequest<TaskDetailsVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
