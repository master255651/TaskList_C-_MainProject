using FluentValidation;

namespace TaskList.Application.Tasks.Queries.GetTaskList
{
    public class GetTaskListQueryValidator : AbstractValidator<GetTaskListQuery>
    {
        public GetTaskListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
