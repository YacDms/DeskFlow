using DeskFlow.Shared.Models;

namespace DeskFlow.Application.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(Guid id);
        Task<TaskItem?> CreateAsync(TaskItem task);
        Task<bool> UpdateAsync(Guid id, TaskItem updated);
        Task<bool> DeleteAsync(Guid id);
    }
}
