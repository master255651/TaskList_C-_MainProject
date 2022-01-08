using FluentValidation;

namespace TaskList.Application.Tasks.Queries.GetTaskDetails
{
    public class GetTaskDetailsQueryValidator : AbstractValidator<GetTaskDetailsQuery>
    {
        public GetTaskDetailsQueryValidator()
        {
            RuleFor(task => task.Id).NotEqual(Guid.Empty);
            RuleFor(task => task.UserId).NotEqual(Guid.Empty);
        }
    }
}
