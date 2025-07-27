using DeskFlow.Shared.Models;

namespace DeskFlow.API.Services
{
    public class ProjectService : IProjectService
    {
        private readonly List<Project> _projects = new();

        public IEnumerable<Project> GetAll() => _projects;

        public Project? GetById(Guid id) =>
            _projects.FirstOrDefault(p => p.Id == id);

        public Project Create(Project project)
        {
            project.Id = Guid.NewGuid();
            project.CreatedAt = DateTime.UtcNow;
            _projects.Add(project);
            return project;
        }

        public bool Update(Guid id, Project updated)
        {
            var project = GetById(id);
            if (project is null) return false;

            project.Title = updated.Title;
            project.Description = updated.Description;
            project.DueDate = updated.DueDate;
            project.Status = updated.Status;

            return true;
        }

        public bool Delete(Guid id)
        {
            var project = GetById(id);
            if (project is null) return false;

            _projects.Remove(project);
            return true;
        }
    }
}
