using DeskFlow.Shared.Models;

namespace DeskFlow.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetAllAsync();
        Task<Project?> GetByIdAsync(Guid id);
        Task<Project> CreateAsync(Project project);
        Task<bool> UpdateAsync(Guid id, Project updated);
        Task<bool> DeleteAsync(Guid id);
    }
}
