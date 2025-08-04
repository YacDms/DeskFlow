using DeskFlow.Application.DTOs.Project;

namespace DeskFlow.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectReadDto>> GetAllAsync();
        Task<ProjectReadDto?> GetByIdAsync(Guid id);
        Task<ProjectReadDetailsDto?> GetDetailedByIdAsync(Guid id);
        Task<ProjectReadDto> CreateAsync(ProjectCreateDto project);
        Task<bool> UpdateAsync(Guid id, ProjectCreateDto updated);
        Task<bool> DeleteAsync(Guid id);
    }
}
