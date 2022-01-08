using FluentValidation;

namespace TaskList.Application.Tasks.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(updateTaskCommand => 
                updateTaskCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateTaskCommand => 
                updateTaskCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateTaskCommand => 
                updateTaskCommand.Title).NotEmpty().MaximumLength(250);
        }
    }
}
