using AutoMapper;
using TaskList.Application.Common.Mappings;
using TaskList.Application.Tasks.Commands.CreateTask;
using System.ComponentModel.DataAnnotations;

namespace TaskList.WebApi.Models
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Title,
                    opt => opt.MapFrom(taskDto => taskDto.Title))
                .ForMember(taskCommand => taskCommand.Details,
                    opt => opt.MapFrom(taskDto => taskDto.Details));
        }
    }
}
