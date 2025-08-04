using DeskFlow.Application.Interfaces;
using DeskFlow.Application.DTOs.Project;
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
    public async Task<ActionResult<IEnumerable<ProjectReadDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectReadDto>> GetById(Guid id)
    {
        var project = await _service.GetByIdAsync(id);
        return project is null ? NotFound() : Ok(project);
    }
    // Renamed to avoid confusion with GetById
    // This endpoint provides detailed information about a project, including its tasks and notes.
    [HttpGet("{id}/details")]
    public async Task<ActionResult<ProjectReadDetailsDto>> GetDetailedById(Guid id) 
    {
        var project = await _service.GetDetailedByIdAsync(id);
        return project is null ? NotFound() : Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectReadDto>> Create(ProjectCreateDto project)
    {
        var created = await _service.CreateAsync(project);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ProjectCreateDto updated)
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
