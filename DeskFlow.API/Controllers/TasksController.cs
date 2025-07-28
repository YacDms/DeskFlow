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
        public ActionResult<IEnumerable<TaskItem>> GetAll() => Ok(_service.GetAll());
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetById(Guid id)
        {
            var task = _service.GetById(id);
            return task is null ? NotFound() : Ok(task);
        }
        [HttpPost]
        public ActionResult<TaskItem> Create(TaskItem task)
        {
            try
            {
                var created = _service.Create(task);
                return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, TaskItem updated)
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
}
