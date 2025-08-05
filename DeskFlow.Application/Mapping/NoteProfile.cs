using AutoMapper;
using DeskFlow.Application.DTOs.Note;
using DeskFlow.Shared.Models;

namespace DeskFlow.Application.Mapping
{
    public class NoteProfile : Profile
    {
        public NoteProfile()
        {
            CreateMap<Note, NoteReadDto>();
            CreateMap<NoteCreateDto, Note>();
        }
    }
}
