using DeskFlow.Application.Interfaces;
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
    public async Task<ActionResult<IEnumerable<Project>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Project>> GetById(Guid id)
    {
        var project = await _service.GetByIdAsync(id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<Project>> Create(Project project)
    {
        var created = await _service.CreateAsync(project);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Project updated)
    {
        var success = await _service.UpdateAsync(id, updated);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}
