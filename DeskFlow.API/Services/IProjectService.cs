using DeskFlow.Shared.Models;

namespace DeskFlow.API.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetAll();
        Project? GetById(Guid id);
        Project Create(Project project);
        bool Update(Guid id, Project updated);
        bool Delete(Guid id);
    }
}
