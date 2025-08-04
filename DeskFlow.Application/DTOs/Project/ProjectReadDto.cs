namespace DeskFlow.Application.DTOs.Project
{
    public class ProjectReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!; 
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
