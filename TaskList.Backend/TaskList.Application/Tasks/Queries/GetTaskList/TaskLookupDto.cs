using AutoMapper;
using TaskList.Application.Common.Mappings;

namespace TaskList.Application.Tasks.Queries.GetTaskList
{
    public class TaskLookupDto : IMapWith<Task>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, TaskLookupDto>()
                .ForMember(taskDto => taskDto.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskDto => taskDto.Title,
                    opt => opt.MapFrom(task => task.Title));
        }
    }
}
