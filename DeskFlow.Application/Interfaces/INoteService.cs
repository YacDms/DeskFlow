using DeskFlow.Shared.Models;

namespace DeskFlow.Application.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAllAsync();
        Task<Note?> GetByIdAsync(Guid id);
        Task<Note?> CreateAsync(Note note);
        Task<bool> UpdateAsync(Guid id, Note updated);
        Task<bool> DeleteAsync(Guid id);
    }
}
