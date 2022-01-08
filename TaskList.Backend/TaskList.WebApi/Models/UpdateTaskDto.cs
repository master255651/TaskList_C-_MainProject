using AutoMapper;
using System;
using TaskList.Application.Common.Mappings;
using TaskList.Application.Tasks.Commands.UpdateTask;

namespace TaskList.WebApi.Models
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Id,
                    opt => opt.MapFrom(taskDto => taskDto.Id))
                .ForMember(taskCommand => taskCommand.Title,
                    opt => opt.MapFrom(taskDto => taskDto.Title))
                .ForMember(taskCommand => taskCommand.Details,
                    opt => opt.MapFrom(taskDto => taskDto.Details));
        }
    }
}
