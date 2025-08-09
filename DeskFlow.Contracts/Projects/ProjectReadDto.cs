using DeskFlow.Shared.Models;

namespace DeskFlow.Contracts.Projects
{
    public class ProjectReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!; 
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
