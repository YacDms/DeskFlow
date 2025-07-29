using DeskFlow.Shared.Models;

namespace DeskFlow.API.Services
{
    public interface ITaskService
    {
        IEnumerable<TaskItem> GetAll();
        TaskItem? GetById(Guid id);
        Task<TaskItem?> Create(TaskItem task);
        bool Update(Guid id, TaskItem updated);
        bool Delete(Guid id);
    }
}
