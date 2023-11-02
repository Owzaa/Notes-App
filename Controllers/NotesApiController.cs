using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Models;
using static Notes.Models.NotesModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesApiController : ControllerBase
    {

        private readonly NotesContext _context;

        public NotesApiController(NotesContext context)
        {
            _context = context;
        }

        // GET: api/Notes
        [HttpGet]
        public Task<ActionResult<IEnumerable<NotesModel>>> GetAsync()
        {
            return Task.FromResult((ActionResult<IEnumerable<NotesModel>>)_context.NotesModel);
        }

        // GET: api/Notes/5
        [HttpGet("{id}")]
        public Task<ActionResult<NotesModel>> GetNote(int id)
        {
            var note = _context.Notes;

            if (note == null)
            {
                return Task.FromResult<ActionResult<NotesModel>>(NotFound());
            }

            return Task.FromResult<ActionResult<NotesModel>> ((ActionResult<NotesModel>)note);
        }

        // POST: api/Notes
        [HttpPost]
        public async Task<ActionResult<NotesModel>> PostNote(NotesModel note)
        {
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNote", new { id = note.Id }, note);
        }

        // PUT: api/Notes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote(int id, NotesModel note)
        {
            if (id != note.Id)
            {
                return BadRequest();
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private bool NoteExists(int id)
        {
            throw new NotImplementedException();
        }


        // DELETE: api/Notes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note =  _context.Notes;
            if (note == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();

            return NoContent();
        }

      
    }
}

