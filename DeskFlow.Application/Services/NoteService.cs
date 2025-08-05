using DeskFlow.Shared.Models;
using DeskFlow.Application.Interfaces;
using DeskFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using DeskFlow.Application.DTOs.Note;
using AutoMapper;

namespace DeskFlow.Application.Services
{
    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;
        private readonly IProjectService _projectService;
        private readonly IMapper _mapper;

        public NoteService(AppDbContext context, IProjectService projectService, IMapper mapper)
        {
            _context = context;
            _projectService = projectService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NoteReadDto>> GetAllAsync()
        {
            var notes = await _context.Notes.ToListAsync();
            return _mapper.Map<IEnumerable<NoteReadDto>>(notes);
        }
        public async Task<NoteReadDto?> GetByIdAsync(Guid id)
        {
            var note = await _context.Notes.FindAsync(id);
            return note is null ? null : _mapper.Map<NoteReadDto>(note);
        } 
        public async Task<NoteReadDto?> CreateAsync(NoteCreateDto dto)
        {
            if (await _projectService.GetByIdAsync(dto.ProjectId) is null)
                return null;

            var note = _mapper.Map<Note>(dto);
            note.Id = Guid.NewGuid();
            note.CreateAt = DateTime.UtcNow;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return _mapper.Map<NoteReadDto>(note);
        }
        public async Task<bool> UpdateAsync(Guid id, NoteCreateDto dto)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note is null) return false;

            _mapper.Map(dto, note);

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
