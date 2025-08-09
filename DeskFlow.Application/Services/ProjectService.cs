using DeskFlow.Contracts.Projects;
using DeskFlow.Shared.Models;
using DeskFlow.Application.Interfaces;
using DeskFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DeskFlow.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProjectService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectReadDto>> GetAllAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            return _mapper.Map<IEnumerable<ProjectReadDto>>(projects);
        }

        public async Task<ProjectReadDto?> GetByIdAsync(Guid id)
        {
            var project = await _context.Projects.FindAsync(id);
            return project is null ? null : _mapper.Map<ProjectReadDto>(project);
        }
        public async Task<ProjectReadDetailsDto?> GetDetailedByIdAsync(Guid id)
        {
            var project = await _context.Projects
                .Include(p => p.Tasks)
                .Include(p => p.Notes)
                .FirstOrDefaultAsync(p => p.Id == id);
            return project is null ? null : _mapper.Map<ProjectReadDetailsDto>(project);
        }
        public async Task<ProjectReadDto> CreateAsync(ProjectCreateDto dto)
        {
            var project = _mapper.Map<Project>(dto);
            project.Id = Guid.NewGuid();
            project.CreatedAt = DateTime.UtcNow;

            _context.Projects.Add(project);

            await _context.SaveChangesAsync();
            return _mapper.Map<ProjectReadDto>(project);
        }

        public async Task<bool> UpdateAsync(Guid id, ProjectCreateDto dto)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project is null) return false;

            _mapper.Map(dto, project);
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
