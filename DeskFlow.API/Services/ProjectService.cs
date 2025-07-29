using DeskFlow.Shared.Models;
using System.Collections.Generic;

namespace DeskFlow.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly List<Project> _projects = new();
        
        public Task<IEnumerable<Project>> GetAllAsync() => Task.FromResult<IEnumerable<Project>>(_projects);

        public Task<Project?> GetByIdAsync(Guid id) =>
            Task.FromResult<Project?>(_projects.FirstOrDefault(p => p.Id == id));

        public Task<Project> CreateAsync(Project project)
        {
            project.Id = Guid.NewGuid();
            project.CreatedAt = DateTime.UtcNow;
            _projects.Add(project);
            return Task.FromResult<Project>(project);
        }

        public Task<bool> UpdateAsync(Guid id, Project updated)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project is null) return Task.FromResult<bool>(false);

            project.Title = updated.Title;
            project.Description = updated.Description;
            project.DueDate = updated.DueDate;
            project.Status = updated.Status;

            return Task.FromResult<bool>(true);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            var project = _projects.FirstOrDefault(p => p.Id == id);
            if (project is null) return Task.FromResult<bool>(false);

            _projects.Remove(project);
            return Task.FromResult<bool>(true);
        }
    }
}
