using AutoMapper;
using DeskFlow.Application.DTOs.Project;
using DeskFlow.Shared.Models;

namespace DeskFlow.Application.Mapping
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectReadDto>();
            CreateMap<Project, ProjectReadDetailsDto>();
            CreateMap<ProjectCreateDto, Project>();
        }
    }
}
