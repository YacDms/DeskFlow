namespace DeskFlow.Shared.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; } // Reference to the project this note belongs to
        public string Content { get; set; } = string.Empty;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
