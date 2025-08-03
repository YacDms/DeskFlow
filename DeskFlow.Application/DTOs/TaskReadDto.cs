using DeskFlow.Shared.Models;

namespace DeskFlow.Application.DTOs
{
    public class TaskReadDto
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
        public TaskState Status { get; set; }
    }
}
