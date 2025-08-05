using DeskFlow.Application.DTOs;

namespace DeskFlow.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDto>> GetAllAsync();
        Task<TaskReadDto?> GetByIdAsync(Guid id);
        Task<TaskReadDto?> CreateAsync(TaskCreateDto dto);
        Task<bool> UpdateAsync(Guid id, TaskCreateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
