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

        public Task<IEnumerable<TaskItem>> GetAllAsync() => Task.FromResult<IEnumerable<TaskItem>>(_tasks);
        public Task<TaskItem?> GetByIdAsync(Guid id) => Task.FromResult<TaskItem?>(_tasks.FirstOrDefault(t => t.Id == id));
        public async Task<TaskItem?> CreateAsync(TaskItem task)
        {
            if (await _projectService.GetByIdAsync(task.ProjectId) is null)
                return null;

            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.UtcNow;
            _tasks.Add(task);
            return task;
        }
        public Task<bool> UpdateAsync(Guid id, TaskItem updated)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task is null) return Task.FromResult(false);

            task.Title = updated.Title;
            task.Description = updated.Description;
            task.DueDate = updated.DueDate;
            task.Status = updated.Status;
            task.ProjectId = updated.ProjectId;

            return Task.FromResult(true);
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task is null) return Task.FromResult(false);

            _tasks.Remove(task);

            return Task.FromResult(true);
        }
    }
}
