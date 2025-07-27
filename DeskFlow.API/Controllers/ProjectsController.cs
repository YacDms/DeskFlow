using DeskFlow.API.Services;
using DeskFlow.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectsController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Project>> GetAll()
    {
        return Ok(_service.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Project> GetById(Guid id)
    {
        var project = _service.GetById(id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public ActionResult<Project> Create(Project project)
    {
        var created = _service.Create(project);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Project updated)
    {
        var success = _service.Update(id, updated);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var success = _service.Delete(id);
        return success ? NoContent() : NotFound();
    }
}
