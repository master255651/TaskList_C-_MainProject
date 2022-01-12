using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskList.Application.Tasks.Queries.GetTaskList;
using TaskList.Application.Tasks.Queries.GetTaskDetails;
using TaskList.Application.Tasks.Commands.CreateTask;
using TaskList.Application.Tasks.Commands.UpdateTask;
using TaskList.Application.Tasks.Commands.DeleteTask;
using TaskList.WebApi.Models;

namespace TaskList.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;

        public TaskController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of tasks
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /task
        /// </remarks>
        /// <returns>Returns TaskListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is in an unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TaskListVm>> GetAll()
        {
            var query = new GetTaskListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the task by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /task/D34D349E-43B8-429E-BCA4-793C932FD580
        /// </remarks>
        /// <param name="id">Task id (guid)</param>
        /// <returns>Returns TaskDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is in an unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<TaskDetailsVm>> Get(Guid id)
        {
            var query = new GetTaskDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the task
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /task
        /// {
        ///     title: "task title",
        ///     details: "task details"
        /// }
        /// </remarks>
        /// <param name="createTaskDto">CreateTaskDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is in an unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            command.UserId = UserId;
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }

        /// <summary>
        /// Updates the task
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /task
        /// {
        ///     title: "updated task title"
        /// }
        /// </remarks>
        /// <param name="updateTaskDto">UpdateTaskDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is in an unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the task by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /task/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">Id of the task (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is in an unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTaskCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
