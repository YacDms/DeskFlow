namespace DeskFlow.Contracts.Notes
{
    public class NoteCreateDto
    {
        public Guid ProjectId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
