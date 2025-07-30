using Microsoft.AspNetCore.Http;
using DeskFlow.Application.Interfaces;
using DeskFlow.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeskFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _service;
        public NotesController(INoteService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Note>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetById(Guid id)
        {
            var note = await _service.GetByIdAsync(id);
            return note is null ? NotFound() : Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> Create(Note note)
        {
            var created = await _service.CreateAsync(note);
            if (created is null)
                return BadRequest(new { error = "Project not found !" });
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Note updated)
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
