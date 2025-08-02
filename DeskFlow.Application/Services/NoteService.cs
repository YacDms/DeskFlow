using DeskFlow.Shared.Models;
using DeskFlow.Application.Interfaces;
using DeskFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DeskFlow.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;
        private readonly IProjectService _projectService;

        public NoteService(AppDbContext context, IProjectService projectService)
        {
            _context = context;
            _projectService = projectService;
        }

        public async Task<IEnumerable<Note>> GetAllAsync() => await _context.Notes.ToListAsync();
        public async Task<Note?> GetByIdAsync(Guid id) => await _context.Notes.FindAsync(id);
        public async Task<Note?> CreateAsync(Note note)
        {
            if (await _projectService.GetByIdAsync(note.ProjectId) is null) return null;

            note.Id = Guid.NewGuid();
            note.CreateAt = DateTime.UtcNow;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return note;
        }
        public async Task<bool> UpdateAsync(Guid id, Note updated)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note is null) return false;

            note.ProjectId = updated.ProjectId;
            note.Content = updated.Content;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);
            if(note is null) return false;
            
            _context.Notes.Remove(note);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
