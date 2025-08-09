using DeskFlow.Shared.Models;
using DeskFlow.Application.Interfaces;
using DeskFlow.Infrastructure.Persistence;
using DeskFlow.Contracts.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DeskFlow.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public TaskService(AppDbContext context, IProjectService projectService, IMapper mapper)
        {
            _context = context;
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TaskReadDto>> GetAllAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return _mapper.Map<IEnumerable<TaskReadDto>>(tasks);
        } 
        public async Task<TaskReadDto?> GetByIdAsync(Guid id) 
        {
            var task = await _context.Tasks.FindAsync(id);
            return task is null ? null : _mapper.Map<TaskReadDto>(task);
        } 
        public async Task<TaskReadDto?> CreateAsync(TaskCreateDto dto)
        {
            if (await _projectService.GetByIdAsync(dto.ProjectId) is null)
                return null;

            var task = _mapper.Map<TaskItem>(dto);
            task.Id = Guid.NewGuid();
            task.CreatedAt = DateTime.UtcNow;

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskReadDto>(task);
        }
        public async Task<bool> UpdateAsync(Guid id, TaskCreateDto dto)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task is null) return false;

            _mapper.Map(dto, task);
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
