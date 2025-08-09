using DeskFlow.Contracts.Projects;

namespace DeskFlow.Application.Interfaces
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectReadDto>> GetAllAsync();
        Task<ProjectReadDto?> GetByIdAsync(Guid id);
        Task<ProjectReadDetailsDto?> GetDetailedByIdAsync(Guid id);
        Task<ProjectReadDto> CreateAsync(ProjectCreateDto dto);
        Task<bool> UpdateAsync(Guid id, ProjectCreateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
