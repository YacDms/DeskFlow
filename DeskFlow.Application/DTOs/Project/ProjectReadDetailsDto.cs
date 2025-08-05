using DeskFlow.Application.DTOs.Note;
using DeskFlow.Shared.Models;

namespace DeskFlow.Application.DTOs.Project
{
    public class ProjectReadDetailsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<TaskReadDto> Tasks { get; set; } = new();
        public List<NoteReadDto> Notes { get; set; } = new();
    }
}
