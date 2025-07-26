using DeskFlow.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private static readonly List<Project> _projects = new();

    [HttpGet]
    public ActionResult<IEnumerable<Project>> GetAll()
    {
        return Ok(_projects);
    }

    [HttpGet("{id}")]
    public ActionResult<Project> GetById(Guid id)
    {
        var project = _projects.FirstOrDefault(p => p.Id == id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public ActionResult<Project> Create(Project project)
    {
        project.Id = Guid.NewGuid();
        project.CreatedAt = DateTime.UtcNow;
        _projects.Add(project);
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Project updated)
    {
        var project = _projects.FirstOrDefault(p => p.Id == id);
        if (project is null) return NotFound();

        project.Title = updated.Title;
        project.Description = updated.Description;
        project.DueDate = updated.DueDate;
        project.Status = updated.Status;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var project = _projects.FirstOrDefault(p => p.Id == id);
        if (project is null) return NotFound();

        _projects.Remove(project);
        return NoContent();
    }
}
