using DeskFlow.Shared.Models;
using DeskFlow.Application.Interfaces;

namespace DeskFlow.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly List<Note> _notes = new();
        private readonly IProjectService _projectService;

        public NoteService(IProjectService projectService)
        {
            _projectService = projectService;
        }

        public Task<IEnumerable<Note>> GetAllAsync() => Task.FromResult<IEnumerable<Note>>(_notes);
        public Task<Note?> GetByIdAsync(Guid id) => Task.FromResult<Note?>(_notes.FirstOrDefault(n => n.Id == id));
        public async Task<Note?> CreateAsync(Note note)
        {
            if (await _projectService.GetByIdAsync(note.ProjectId) is null) return null;

            note.Id = Guid.NewGuid();
            note.CreateAt = DateTime.UtcNow;
            _notes.Add(note);
            return note;
        }
        public Task<bool> UpdateAsync(Guid id, Note updated)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if (note is null) return Task.FromResult<bool>(false);

            note.ProjectId = updated.ProjectId;
            note.Content = updated.Content;

            return Task.FromResult<bool>(true);
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            var note = _notes.FirstOrDefault(n => n.Id == id);
            if(note is null) return Task.FromResult<bool>(false);
            
            _notes.Remove(note);

            return Task.FromResult<bool>(true);
        }
    }
}
