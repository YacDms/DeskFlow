using AutoMapper;
using DeskFlow.Contracts.Projects;
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
