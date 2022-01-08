using AutoMapper;
using TaskList.Application.Common.Mappings;

namespace TaskList.Application.Tasks.Queries.GetTaskDetails
{
    public class TaskDetailsVm : IMapWith<Task>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, TaskDetailsVm>()
                .ForMember(taskVm => taskVm.Title,
                    opt => opt.MapFrom(task => task.Title))
                .ForMember(taskVm => taskVm.Details,
                    opt => opt.MapFrom(task => task.Details))
                .ForMember(taskVm => taskVm.Id,
                    opt => opt.MapFrom(task => task.Id))
                .ForMember(taskVm => taskVm.CreationDate,
                    opt => opt.MapFrom(task => task.CreationDate))
                .ForMember(taskVm => taskVm.EditDate,
                    opt => opt.MapFrom(task => task.EditDate));
        }
    }
}
