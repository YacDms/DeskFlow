using DeskFlow.Shared.Models;
using DeskFlow.Application.Interfaces;
using DeskFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync() => await _context.Projects.ToListAsync();

        public async Task<Project?> GetByIdAsync(Guid id) =>
            await _context.Projects.FindAsync(id);

        public async Task<Project> CreateAsync(Project project)
        {
            project.Id = Guid.NewGuid();
            project.CreatedAt = DateTime.UtcNow;
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<bool> UpdateAsync(Guid id, Project updated)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project is null) return false;

            project.Title = updated.Title;
            project.Description = updated.Description;
            project.DueDate = updated.DueDate;
            project.Status = updated.Status;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project is null) return false;

            _context.Projects.Remove(project);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
