using FluentValidation;

namespace TaskList.Application.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createTaskCommand =>
                createTaskCommand.Title).NotEmpty().MaximumLength(250);
            RuleFor(createTaskCommand =>
                createTaskCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
