using DeskFlow.Application.DTOs.Note;

namespace DeskFlow.Application.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteReadDto>> GetAllAsync();
        Task<NoteReadDto?> GetByIdAsync(Guid id);
        Task<NoteReadDto?> CreateAsync(NoteCreateDto dto);
        Task<bool> UpdateAsync(Guid id, NoteCreateDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
