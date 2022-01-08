using FluentValidation;

namespace TaskList.Application.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(deleteTaskCommand => deleteTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteTaskCommand => deleteTaskCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
