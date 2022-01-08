using MediatR;

namespace TaskList.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQuery : IRequest<TaskListVm>
    {
        public Guid UserId { get; set; }
    }
}
