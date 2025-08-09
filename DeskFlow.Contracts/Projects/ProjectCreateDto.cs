namespace DeskFlow.Contracts.Projects
{
    public class ProjectCreateDto
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
