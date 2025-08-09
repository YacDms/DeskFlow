using AutoMapper;
using DeskFlow.Contracts.Tasks;
using DeskFlow.Shared.Models;

namespace DeskFlow.Application.Mapping
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TaskItem, TaskReadDto>(); // TaskItem -> TaskReadDto Because TaskReadDto is used to read tasks
            CreateMap<TaskCreateDto, TaskItem>(); // TaskCreateDto -> TaskItem Because TaskCreateDto is used to create a new task
        }
    }
}
