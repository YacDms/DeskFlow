namespace DeskFlow.Application.DTOs.Note
{
    public class NoteCreateDto
    {
        public Guid ProjectId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
