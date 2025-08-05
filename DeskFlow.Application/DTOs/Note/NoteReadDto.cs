namespace DeskFlow.Application.DTOs.Note
{
    public class NoteReadDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; } // Reference to the project this note belongs to
        public string Content { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; }
    }
}
