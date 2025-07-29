using Microsoft.AspNetCore.Http;
using DeskFlow.API.Services;
using DeskFlow.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;
        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(Guid id)
        {
            var task = await _service.GetByIdAsync(id);
            return task is null ? NotFound() : Ok(task);
        }
        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskItem task)
        {
            var created = await _service.CreateAsync(task);
            if(created is null)
                return BadRequest(new { error = "Project not found !" });
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, TaskItem updated)
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
}
