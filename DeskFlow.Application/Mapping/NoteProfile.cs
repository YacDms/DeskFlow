using AutoMapper;
using DeskFlow.Contracts.Notes;
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
