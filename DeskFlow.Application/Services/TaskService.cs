using DeskFlow.Shared.Models;
using DeskFlow.Application.Interfaces;
using DeskFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IProjectService _projectService;

        public TaskService(AppDbContext context)
        {
            _context = context;
            _projectService = new ProjectService(context);
        }

        public async Task<IEnumerable<TaskItem>> GetAllAsync() => await _context.Tasks.ToListAsync();
        public async Task<TaskItem?> GetByIdAsync(Guid id) => await _context.Tasks.FindAsync(id);
        public async Task<TaskItem?> CreateAsync(TaskItem task)
        {
            if (await _projectService.GetByIdAsync(task.ProjectId) is null)
                return null;

            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.UtcNow;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<bool> UpdateAsync(Guid id, TaskItem updated)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null) return false;

            task.Title = updated.Title;
            task.Description = updated.Description;
            task.DueDate = updated.DueDate;
            task.Status = updated.Status;
            task.ProjectId = updated.ProjectId;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
