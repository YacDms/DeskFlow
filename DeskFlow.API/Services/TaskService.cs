using DeskFlow.Shared.Models;

namespace DeskFlow.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private readonly IProjectService _projectService;

        public TaskService(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public IEnumerable<TaskItem> GetAll() => _tasks;
        public TaskItem? GetById(Guid id) => _tasks.FirstOrDefault(t => t.Id == id);
        public async Task<TaskItem?> Create(TaskItem task)
        {
            if (await _projectService.GetByIdAsync(task.ProjectId) is null)
                return null;

            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.UtcNow;
            _tasks.Add(task);
            return task;
        }
        public bool Update(Guid id, TaskItem updated)
        {
            var task = GetById(id);
            if (task is null) return false;

            task.Title = updated.Title;
            task.Description = updated.Description;
            task.DueDate = updated.DueDate;
            task.Status = updated.Status;
            task.ProjectId = updated.ProjectId;

            return true;
        }
        public bool Delete(Guid id)
        {
            var task = GetById(id);
            if (task is null) return false;

            _tasks.Remove(task);

            return true;
        }
    }
}
