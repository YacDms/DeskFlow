using DeskFlow.Application.DTOs;

namespace DeskFlow.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskReadDto>> GetAllAsync();
        Task<TaskReadDto?> GetByIdAsync(Guid id);
        Task<TaskReadDto?> CreateAsync(TaskCreateDto task);
        Task<bool> UpdateAsync(Guid id, TaskCreateDto updated);
        Task<bool> DeleteAsync(Guid id);
    }
}
