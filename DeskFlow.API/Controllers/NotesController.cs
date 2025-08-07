using Microsoft.AspNetCore.Http;
using DeskFlow.Application.Interfaces;
using DeskFlow.Application.DTOs.Note;
using Microsoft.AspNetCore.Mvc;
using DeskFlow.Application.Exceptions;

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
        public async Task<ActionResult<IEnumerable<NoteReadDto>>> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("test-error")] // To test catching errors in middleware
        public IActionResult TestError()
        {
            throw new Exception("Erreur simulée !");
        }

        [HttpGet("NotFoundExpetionTest")] // To test catching NotFoundException in middleware
        public IActionResult TestNotFound()
        {
            throw new NotFoundException("NorFoundException simulée !");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NoteReadDto>> GetById(Guid id)
        {
            var note = await _service.GetByIdAsync(id);
            return note is null ? NotFound() : Ok(note);
        }

        [HttpPost]
        public async Task<ActionResult<NoteReadDto>> Create(NoteCreateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            if (created is null)
                return BadRequest(new { error = "Project not found !" });
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, NoteCreateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
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
