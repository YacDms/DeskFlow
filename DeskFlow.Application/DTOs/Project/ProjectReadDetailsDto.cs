using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskFlow.Application.DTOs.Project
{
    public class ProjectReadDetailsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }

        public List<TaskReadDto> Tasks { get; set; } = new();
    }
}
