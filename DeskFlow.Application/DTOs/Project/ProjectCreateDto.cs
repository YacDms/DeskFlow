namespace DeskFlow.Application.DTOs.Project
{
    public class ProjectCreateDto
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
